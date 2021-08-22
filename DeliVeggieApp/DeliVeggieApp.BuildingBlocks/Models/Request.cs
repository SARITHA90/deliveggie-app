namespace DeliVeggieApp.Infrastructure.BuildingBlocks.Models
{
    public class Request<T> : IRequest
    {
        public T Data { get; set; }
    }
}
