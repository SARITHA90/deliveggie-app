using DeliVeggieApp.BuildingBlocks.Entities;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DeliVeggieApp.Infrastructure.BuildingBlocks.DataBaseContext
{
    public static class ProductContextSeedData
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Uncle Bens Rice",
                    Price= 23.00,
                    EntryDate=System.DateTime.Now                   
                },
                 new Product()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "A Pile of Potots",
                    Price= 27.00,
                    EntryDate=System.DateTime.Now
                }
            };
        }
    }
}

