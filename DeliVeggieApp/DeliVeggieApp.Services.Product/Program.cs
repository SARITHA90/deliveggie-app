using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Requests;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Responses;
using DeliVeggieApp.Infrastructure.Messaging;
using DeliVeggieApp.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DeliVeggieApp.Services.Products
{
    internal class Program
    {
        private static ServiceProvider _services;
        private static IProductRepository _productService;
        private static void Main(string[] args)
        {
            Console.WriteLine("Product Microservice Started...");
            _services = new ServiceCollection()
                .AddSingleton<ISubscriber>(x => new Subscriber())
                .AddSingleton<IProductRepository>(x => new ProductRepository())
                .BuildServiceProvider();
            var bus = _services.GetService<ISubscriber>();
            _productService = _services.GetService<IProductRepository>();
            while (true)
            {
                bus?.Subscribe(EventHandler);
            }
        }
        /// <summary>
        /// Callback event of subscribe 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private static IResponse EventHandler(IRequest arg)
        {
            switch (arg)
            {
                case Request<ProductsRequest> productsRequestCommand:
                    {
                        Console.WriteLine($"Request has been published to retrieve all products.");

                        var details = Task.Run(async () =>
                        {
                            return await _productService.GetProductsAsync(new ProductsRequest());
                        }).GetAwaiter().GetResult();
                        IResponse data = new Response<ProductsResponse>() { Data = details };
                        return data;

                    }

                case Request<ProductDetailsRequest> detailsRequestCommand:
                    {
                        Console.WriteLine($"Request has been published to retrieve details of product with ID {detailsRequestCommand.Data.Id}.");

                        var details = Task.Run(async () =>
                        {
                            return await _productService.GetProductAsync(new ProductDetailsRequest { Id = detailsRequestCommand.Data.Id });
                        }).GetAwaiter().GetResult();
                        IResponse data = new Response<ProductDetailsResponse>() { Data = details };
                        return data;


                    }

                default:
                    return null;
            }

        }
    }
}
