using DeliVeggieApp.Infrastructure.BuildingBlocks.DataBaseContext;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliVeggieApp.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly IProductContext _context;

        public ProductRepository(IProductContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async  Task<IEnumerable<ProductsResponse>> GetProducts()
        {
            var products= await _context.Products.Find(c => true).ToListAsync();
            var response = products.Select(x => new ProductsResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return response;
           
            //TODO: create  response here
        }

        public async Task<ProductDetailsResponse> GetProduct(ProductDetailsRequest  req)
        {
            var product = await _context.Products.Find(c => c.Id == req.Id).FirstOrDefaultAsync();      
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
