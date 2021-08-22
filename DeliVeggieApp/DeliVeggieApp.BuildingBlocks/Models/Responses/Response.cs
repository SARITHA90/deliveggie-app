namespace DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Responses
{
    public class Response<T> : IResponse
    {
        public T Data { get; set; }
    }
}
