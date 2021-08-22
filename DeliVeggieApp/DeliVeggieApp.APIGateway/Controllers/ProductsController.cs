using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Requests;
using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Responses;
using DeliVeggieApp.Infrastructure.Messaging;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DeliVeggieApp.APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IPublisher _publisher;
        public ProductsController(IPublisher publisher)
        {
            _publisher = publisher;
        }

        [HttpGet]       
        public IActionResult GetAllProducts()
        
        {
            var request = new Request<ProductsRequest>() { Data = new ProductsRequest() };
            var data = _publisher.Publish(request);
            if (!(data is Response<ProductsResponse> response))
            {
                return NotFound();
            }
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(string id)
        {
            var request = new Request<ProductDetailsRequest>() { Data = new ProductDetailsRequest() { Id = id } };
           
             var data = _publisher.Publish(request);
            if (!(data is Response<ProductDetailsResponse> response))
            {
                return NotFound();
            }
            return Ok(response.Data);
        }
    }
}
