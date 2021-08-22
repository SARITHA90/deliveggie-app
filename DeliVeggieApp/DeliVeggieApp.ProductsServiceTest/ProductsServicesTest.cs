using DeliVeggieApp.Infrastructure.BuildingBlocks.Models.Requests;
using DeliVeggieApp.Repositories;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DeliVeggieApp.ProductsServiceTest
{
    
    public class ProductsServicesTest
    {
        
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestGetProducts()
        {
            var _service = new ProductRepository();
            var details = Task.Run(async () =>
            {
                return await _service.GetProductsAsync(new ProductsRequest());
            }).GetAwaiter().GetResult();
            Assert.IsTrue(details.ProductsList.Count>0);
        }
        [Test]
        public void TestGetProduct()
        {
            var _service = new ProductRepository();
            var id = "6122817d88016ed3e055e0a2";
            var details = Task.Run(async () =>
            {
                return await _service.GetProductAsync(new ProductDetailsRequest() { Id = id });
            }).GetAwaiter().GetResult();
            Assert.IsTrue(details.Product!=null);
        }
    }
}