using DeliVeggieApp.Infrastructure.BuildingBlocks.Models;
using EasyNetQ;
using System.Threading.Tasks;

namespace DeliVeggieApp.Infrastructure.Messaging.Publisher
{
    public class Publisher : IPublisher
    {
        public readonly IBus _bus;

        public Publisher()
        {
            _bus = RabbitHutch.CreateBus("host=localhost");
        }

        public async Task<IResponse> Publish(IRequest request)
        {
            return await _bus.Rpc.RequestAsync<IRequest, IResponse>(request);
        }  

      
    }
}
