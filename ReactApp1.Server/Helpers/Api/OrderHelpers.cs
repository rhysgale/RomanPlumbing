namespace ReactApp1.Server.Helpers.Api
{
    public static class OrderHelpers
    {
        public static Models.Api.Order DbOrderToApiOrder(this Models.Database.Order order)
        {
            return new Models.Api.Order
            {
                OrderDetails = order.Details.Select(detail => new Models.Api.OrderDetail
                {
                    LineAmount = detail.LineAmount,
                    ProductName = detail.ProductName
                }),
                Address = new Models.Api.Address()
                {
                    City = order.Address.City,
                    County = order.Address.County,
                    PostCode = order.Address.PostCode,
                    Street = order.Address.Street
                },
                OrderReference = order.OrderReference
            };
        }

        public static Models.Endpoints.OrderSummary ApiOrderToEndpointOrderSummary(this Models.Api.Order order)
        {
            // For simplicity, just use the top order detail
            return new Models.Endpoints.OrderSummary
            {
                OrderReference = order.OrderReference,
                ProductName = order.OrderDetails.FirstOrDefault()?.ProductName ?? string.Empty,
                TotalCost = order.OrderDetails.FirstOrDefault()?.LineAmount ?? 0
            };
        }
    }
}
