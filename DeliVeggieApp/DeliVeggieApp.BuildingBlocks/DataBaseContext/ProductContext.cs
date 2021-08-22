using DeliVeggieApp.BuildingBlocks.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DeliVeggieApp.Infrastructure.BuildingBlocks.DataBaseContext
{
    public class ProductContext : IProductContext
    {
        public ProductContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DeliVeggieDB");
            Products = database.GetCollection<Products>("Products");
            Reductions = database.GetCollection<PriceReductions>("PriceReductions");
            ProductContextSeedData.SeedData(Products);
        }

        public IMongoCollection<Products> Products { get; }
        public IMongoCollection<PriceReductions> Reductions { get; }
    }
}
