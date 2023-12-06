using Microsoft.EntityFrameworkCore;
using ReactApp1.Server.Helpers.Api;

namespace ReactApp1.Server.Api
{
    public class Orders
    {
        private readonly Models.Database.RetailContext retailContext;

        public Orders(Models.Database.RetailContext retailContext)
        {
            this.retailContext = retailContext;
        }

        public string PlaceOrder(Models.Api.Product product, int quantity, Models.Api.Customer customer)
        {
            // TODO: Separate customer and order creation. 
            // This isn't an ideal way of creating an order

            if (customer.Email == null)
            {
                throw new Exception("Email cannot be null");
            }

            if (customer.Name == null)
            {
                throw new Exception("Name cannot be null");
            }

            var dbOrder = new Models.Database.Order
            {
                CustomerEmail = customer.Email,
                CustomerName = customer.Name,
                OrderReference = Guid.NewGuid().ToString(),
                Address = new Models.Database.Address()
                {
                    City = customer.Address.City,
                    County = customer.Address.County,
                    Street = customer.Address.Street,
                    PostCode = customer.Address.PostCode
                },
                Details = new List<Models.Database.OrderDetail>
                {
                    new Models.Database.OrderDetail
                    {
                        LineAmount = product.Price,
                        ProductName = product.Name,
                        ProductSku = product.ProductSku,
                        Quantity = quantity
                    }
                }
            };

            retailContext.Orders.Add(dbOrder);
            retailContext.SaveChanges();

            return dbOrder.OrderReference;
        }

        public Models.Api.Order GetOrder(string orderRef)
        {
            var dbOrder = retailContext.Orders
                    .Include(x => x.Details)
                    .Include(x => x.Address)
                    .First(x => x.OrderReference == orderRef);

            return dbOrder.DbOrderToApiOrder();
        }
    }
}
