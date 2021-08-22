namespace DeliVeggieApp.Infrastructure.BuildingBlocks.Models
{
    public class Response<T> : IResponse
    {
        public T Data { get; set; }
    }
}
