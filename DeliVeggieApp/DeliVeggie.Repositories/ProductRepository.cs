using DeliVeggieApp.BuildingBlocks.Entities;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Requests;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Responses;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliVeggieApp.Repositories
{
    public class ProductRepository: IProductRepository
    {
            
         private readonly IMongoCollection<Product> _products;

        public ProductRepository()
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DeliVeggieDB");
            _products = database.GetCollection<Product>("Products");
        }
        public async  Task<List<ProductsResponse>> GetProducts(ProductsRequest request)
        {
                var products = await _products.Find(c => true).ToListAsync();
                var response = products.Select(x => new ProductsResponse
                {
                    Id =x.Id,
                    Name = x.Name
                }).ToList();
                return response;
           
           
            //TODO: create  response here
        }

        public async Task<ProductDetailsResponse> GetProduct(ProductDetailsRequest  req)
        {
            var product = await _products.Find(c => c.Id == req.Id).FirstOrDefaultAsync();      
             var response = new ProductDetailsResponse
            {
                Id = product.Id,
                Name = product.Name,
                EntryDate = product.EntryDate,
                CurrentPrice = product.Price
            };
            return response;
            //TODO: add price reduction logic here
        }
    }
}
