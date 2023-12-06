using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Helpers.Api;

namespace ReactApp1.Server.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class DataController : Controller
    {
        private readonly Api.Products productsApi;

        public DataController(Api.Products productsApi)
        {
            this.productsApi = productsApi;
        }

        /// <summary>
        /// A test endpoint to populate the basic product table for the UI to fetch
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddTestProducts")]
        public IActionResult AddTestProducts()
        {
            var random = new Random();

            productsApi.AddProduct(new Models.Api.Product
            {
                Name = "J-Shaped 1700mm Single Ended Bath + Curved panel",
                Description = "Introducing the stylish acrylic J Shaped bath",
                Price = 299.99m,
                ImageUrl = "/src/assets/DefaultProductImage.png",
                ProductSku = random.Next(50000, 100000).ToString(), //Not ideal
                Reference = Guid.NewGuid().ToString() // Generate a reference for the UI
            });

            productsApi.AddProduct(new Models.Api.Product
            {
                Name = "1700 x 750 Modern Curved Single Ended Corner Bath",
                Description = "The space saving...",
                Price = 229.99m,
                ImageUrl = "/src/assets/DefaultProductImage.png",
                ProductSku = random.Next(50000, 100000).ToString(), //Not ideal
                Reference = Guid.NewGuid().ToString() // Generate a reference for the UI
            });

            productsApi.AddProduct(new Models.Api.Product
            {
                Name = "Gold Plated 1700mm Single Ended Bath",
                Description = "Bath in luxury with our gold plated bath",
                Price = 1099.99m,
                ImageUrl = "/src/assets/DefaultProductImage.png",
                ProductSku = random.Next(50000, 100000).ToString(), //Not ideal
                Reference = Guid.NewGuid().ToString() // Generate a reference for the UI
            });

            return Json(true);
        }
    }
}
