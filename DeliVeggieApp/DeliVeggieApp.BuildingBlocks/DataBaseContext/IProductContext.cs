using DeliVeggieApp.BuildingBlocks.Entities;
using MongoDB.Driver;

namespace DeliVeggieApp.Infrastructure.BuildingBlocks.DataBaseContext
{
    public interface IProductContext
    {
            IMongoCollection<Product> Products { get; }
       
    }
}
