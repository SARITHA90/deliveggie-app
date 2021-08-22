using DeliVeggieApp.Infrastructure.BuildingBlocks.DataBaseContext;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Requests;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Responses;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeliVeggieApp.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly IProductContext _context;

        public ProductRepository()
        {
            _context = new ProductContext();
        }
        /// <summary>
        /// To fetch all products
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ProductsResponse> GetProductsAsync(ProductsRequest request)
        {
            var unMappedProducts = await _context.Products.Find(c => true).ToListAsync();
            var response = unMappedProducts.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name
            })?.ToList();
            return new ProductsResponse { ProductsList = response };
        }

        /// <summary>
        /// Fetch product by Id
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<ProductDetailsResponse> GetProductAsync(ProductDetailsRequest req)
        {
            var product = await _context.Products.Find(c => c.Id == req.Id).FirstOrDefaultAsync();
            if (product == null) return null;
            var dayOfWeek = (int)DateTime.Today.DayOfWeek + 1;

            //we can implement caching for Price Reduction data, since its constant for all products
            var reductionData = await _context.Reductions.Find(c => c.DayOfWeek == dayOfWeek).FirstOrDefaultAsync();
            var totalReductions = reductionData != null ? (product.Price * reductionData.Reduction) : 0.00;

            var response = new Product
            {
                Id = product.Id,
                Name = product.Name,
                EntryDate = product.EntryDate,
                CurrentPrice = product.Price - totalReductions
            };
            return new ProductDetailsResponse { Product = response };           
        }
    }
}
