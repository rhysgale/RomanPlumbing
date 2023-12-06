using Microsoft.AspNetCore.Mvc;
using ReactApp1.Server.Helpers.Api;

namespace ReactApp1.Server.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly Api.Products productsApi;
        private readonly Api.Orders ordersApi;
        private readonly Api.Payments paymentsApi;

        public OrderController(Api.Products productsApi, Api.Orders ordersApi, Api.Payments paymentsApi)
        {
            this.productsApi = productsApi;
            this.ordersApi = ordersApi;
            this.paymentsApi = paymentsApi;
        }

        public class ConfirmOrderRequest
        {
            public string ProductReference {  get; set; }
            public int ProductQuantity { get; set; }
            public Models.Api.Customer Customer { get; set; }
        }

        public class ConfirmOrderResponse
        {
            public string OrderReference { get; set; }
        }

        /// <summary>
        /// Endpoint for creating a new order
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost("ConfirmOrder")]
        public IActionResult ConfirmOrder([FromBody] ConfirmOrderRequest request)
        {
            var product = productsApi.GetProduct(request.ProductReference);

            // Check the provided productID from the request exists
            if (product == null)
            {
                throw new Exception("Product does not exist");
            }

            // Just as an example. 
            // Typically I have done this to a payment providers website, and then the placing order happens within a callback, storing a transaction in the DB
            var paymentSuccess = paymentsApi.TakePayment(request.Customer.Card);
            if (paymentSuccess == false)
            {
                throw new Exception("Card declined");
            }

            var orderRef = ordersApi.PlaceOrder(product, request.ProductQuantity, request.Customer);
            if (orderRef == null)
            {
                throw new Exception("Failed to place order");
            }

            return Ok(new ConfirmOrderResponse
            {
                OrderReference = orderRef
            });
        }

        public class GetOrderResponse
        {
            public Models.Endpoints.OrderSummary OrderSummary { get; set; }
        }

        /// <summary>
        /// Endpoint for fetching an order given a reference
        /// </summary>
        /// <param name="orderReference"></param>
        /// <returns></returns>
        [HttpGet("GetOrder/{orderReference}")]
        public IActionResult GetOrder(string orderReference)
        {
            var order = ordersApi.GetOrder(orderReference);

            return Json(new GetOrderResponse
            {
                OrderSummary = order.ApiOrderToEndpointOrderSummary()
            });
        }
    }
}
