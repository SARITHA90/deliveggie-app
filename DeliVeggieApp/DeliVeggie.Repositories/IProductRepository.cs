using DeliVeggieApp.BuildingBlocks.Entities;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Requests;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeliVeggieApp.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductsResponse>> GetProducts(ProductsRequest request);
        Task<ProductDetailsResponse> GetProduct(ProductDetailsRequest request);
    }
}
