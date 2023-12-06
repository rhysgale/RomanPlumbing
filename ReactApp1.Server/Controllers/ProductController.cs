using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Helpers.Api;

namespace ReactApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly Api.Products productsApi;

        public ProductController(Api.Products productsApi)
        {
            this.productsApi = productsApi;
        }

        public class GetProductsResponse
        {
            public IEnumerable<Models.Endpoints.Product> Products { get; set; }
        }

        [HttpPost("GetProducts")]
        public IActionResult GetProducts()
        {
            var products = productsApi.GetProducts();

            return Json(new GetProductsResponse()
            {
                Products = products.Select(product => product.ApiProductToEndpointProduct())
            });
        }

        public class GetProductRequest
        {
            public string Reference { get; set; }
        }

        public class GetProductResponse
        {
            public Models.Endpoints.Product Product { get; set; }
        }

        [HttpGet("GetProduct/{reference}")]
        public IActionResult GetProduct(string reference)
        {
            var product = productsApi.GetProduct(reference);

            return Json(new GetProductResponse()
            {
                Product = product.ApiProductToEndpointProduct()
            });
        }
    }
}
