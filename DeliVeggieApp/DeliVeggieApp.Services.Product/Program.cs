
using DeliVeggieApp.Infrastructure.BuildingBlocks.DataBaseContext;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models;
using DeliVeggieApp.Infrastructure.Messaging.Subscriber;
using DeliVeggieApp.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliVeggieApp.Services.Product
{
    internal class Program
    {
        private static ServiceProvider _services;
        private static IProductRepository _productService;
        static void Main(string[] args)
        {
            Console.WriteLine("Product Microservice Started..");
            _services = new ServiceCollection()               
                .AddSingleton<ISubscriber>(x => new Subscriber())
                .AddSingleton<IProductRepository>(x => new ProductRepository(new ProductContext()))
                .BuildServiceProvider();
            var bus = _services.GetService<ISubscriber>();
            _productService = _services.GetService<IProductRepository>();
            while (true)
            {
                bus?.Subscribe(EventHandler);
            }
        }

        private static IResponse EventHandler(IRequest arg)
        {

            if (arg is Request<ProductDetailsRequest> detailsRequest)
            {
                Console.WriteLine($"Gateway sent a request to retrieve details of product with ID {detailsRequest.Data.Id}.");
                //var details = productResponses.Where(a => a.Id == detailsRequest.Data.Id).FirstOrDefault();

                var details = Task.Run(async () =>
                {
                    return await _productService.GetProduct(new ProductDetailsRequest {Id= detailsRequest.Data.Id });
                }).GetAwaiter().GetResult();
                IResponse data = new Response<ProductDetailsResponse>() { Data = details };
                return data;

            }
            else
            {
                Console.WriteLine($"Gateway sent a request to retrieve all products.");

                var details = Task.Run(async () =>
                {
                    return await _productService.GetProducts();
                }).GetAwaiter().GetResult();
                IResponse data = new Response<List<ProductsResponse>>() { Data= details?.ToList()};
                return data;
            }

        }
    }
}
