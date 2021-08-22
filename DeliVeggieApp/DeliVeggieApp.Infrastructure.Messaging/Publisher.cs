using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Requests;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Responses;
using EasyNetQ;

namespace DeliVeggieApp.Infrastructure.Messaging
{
    public class Publisher : IPublisher
    {
        public readonly IBus _bus;

        public Publisher()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
        }

        public IResponse Publish(IRequest request)
        {
            return _bus.Request<IRequest, IResponse>(request);
        }
    }
}
