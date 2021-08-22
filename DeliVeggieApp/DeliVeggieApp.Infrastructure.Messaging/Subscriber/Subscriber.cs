using DeliVeggieApp.Infrastructure.BuildingBlocks.Models;
using EasyNetQ;
using System;

namespace DeliVeggieApp.Infrastructure.Messaging.Subscriber
{
    public class Subscriber:ISubscriber
    {

        public readonly IBus _bus;

        public Subscriber()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
        }

        public void Subscribe(Func<IRequest, IResponse> response)
        {
            _bus.Rpc.RespondAsync(response);
        }


    }
}
