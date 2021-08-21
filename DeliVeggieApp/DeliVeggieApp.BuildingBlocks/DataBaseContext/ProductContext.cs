using DeliVeggieApp.BuildingBlocks.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DeliVeggieApp.Infrastructure.BuildingBlocks.DataBaseContext
{
    public class ProductContext
    {
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DeliVeggieDB");
            Products = database.GetCollection<Product>("Products");
            ProductContextSeedData.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
