using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Requests;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Responses;
using EasyNetQ;
using System;

namespace DeliVeggieApp.Infrastructure.Messaging
{
    public class Subscriber:ISubscriber
    {


        public readonly IBus _bus;

        public Subscriber()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
        }
        public void Subscribe(Func<IRequest, IResponse> data)
        {
            _bus.Respond<IRequest, IResponse>(data);
        }


    }
}
