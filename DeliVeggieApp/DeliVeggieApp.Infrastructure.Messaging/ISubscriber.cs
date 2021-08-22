using DeliVeggieApp.Infrastructure.BuildingBlocks.Models;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Requests;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Responses;
using System;

namespace DeliVeggieApp.Infrastructure.Messaging
{
    public interface ISubscriber
    {
        void Subscribe(Func<IRequest, IResponse> data);
    }
}
