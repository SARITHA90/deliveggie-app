using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Requests;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliVeggieApp.Repositories
{
    public interface IProductRepository
    {
        Task<ProductsResponse> GetProductsAsync(ProductsRequest request);
        Task<ProductDetailsResponse> GetProductAsync(ProductDetailsRequest request);
    }
}
