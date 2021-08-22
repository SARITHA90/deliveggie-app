using DeliVeggieApp.BuildingBlocks.Entities;
using MongoDB.Driver;

namespace DeliVeggieApp.Infrastructure.BuildingBlocks.DataBaseContext
{
    public interface IProductContext
    {
        IMongoCollection<Products> Products { get; }
        IMongoCollection<PriceReductions> Reductions { get; }

    }
}
