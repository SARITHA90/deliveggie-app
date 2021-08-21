using DeliVeggieApp.BuildingBlocks.Entities;
using DeliVeggieApp.Infrastructure.BuildingBlocks.DataBaseContext;
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
        public async  Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(c => true).ToListAsync();
            //TODO: create  response here
        }

        public async Task<Product> GetProduct(string id)
        {
            var product = await _context.Products.Find(c => c.Id == id).FirstOrDefaultAsync();
            return product;
            //TODO: add price reduction logic here
        }
    }
}
