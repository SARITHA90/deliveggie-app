using DeliVeggieApp.Infrastructure.BuildingBlocks.Models;
using System.Threading.Tasks;

namespace DeliVeggieApp.Infrastructure.Messaging.Publisher
{
    public interface IPublisher
    {
        Task<IResponse> Publish(IRequest request);
    }
}
