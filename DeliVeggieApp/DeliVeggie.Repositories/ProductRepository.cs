using DeliVeggieApp.BuildingBlocks.Entities;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Requests;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Responses;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace DeliVeggieApp.Repositories
{
    public class ProductRepository: IProductRepository
    {
            
         private readonly IMongoCollection<Products> _products;

        public ProductRepository()
        {

            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DeliVeggieDB");
            _products = database.GetCollection<Products>("Products");
        }
        public async Task<ProductsResponse> GetProductsAsync(ProductsRequest request)
        {
            var unMappedProducts = await _products.Find(c => true).ToListAsync();
            var response = unMappedProducts.Select(p => new Product
            {
                Id = p.Id,
                Name = p.Name
            })?.ToList();
            return new ProductsResponse { ProductsList = response };
        }

        public async Task<ProductDetailsResponse> GetProductAsync(ProductDetailsRequest  req)
        {
            var product = await _products.Find(c => c.Id == req.Id).FirstOrDefaultAsync();
            if (product == null) return null;
            var response = new Product
            {
                Id = product.Id,
                Name = product.Name,
                EntryDate = product.EntryDate,
                CurrentPrice = product.Price
            };
            return new ProductDetailsResponse { Product = response };
            //TODO: add price reduction logic here
        }
    }
}
