namespace DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Requests
{
    public class Request<T> : IRequest
    {
        public T Data { get; set; }
    }
}
