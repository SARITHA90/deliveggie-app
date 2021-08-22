using DeliVeggieApp.BuildingBlocks.Entities;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliVeggieApp.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductsResponse>> GetProducts();
        Task<ProductDetailsResponse> GetProduct(ProductDetailsRequest request);
    }
}
