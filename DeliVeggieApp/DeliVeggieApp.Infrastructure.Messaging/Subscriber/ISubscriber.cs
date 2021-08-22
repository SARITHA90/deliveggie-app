using DeliVeggieApp.Infrastructure.BuildingBlocks.Models;
using System;

namespace DeliVeggieApp.Infrastructure.Messaging.Subscriber
{
    public interface ISubscriber
    {
        void Subscribe(Func<IRequest, IResponse> response);
    }
}
