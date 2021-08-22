using DeliVeggieApp.Infrastructure.BuildingBlocks.Models;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Requests;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Responses;
using System.Threading.Tasks;

namespace DeliVeggieApp.Infrastructure.Messaging
{
    public interface IPublisher
    {
        IResponse Publish(IRequest request);
    }
}
