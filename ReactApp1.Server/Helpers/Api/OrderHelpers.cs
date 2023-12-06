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
                    ProductName = detail.ProductName,
                    Quantity = detail.Quantity
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
            return new Models.Endpoints.OrderSummary
            {
                OrderReference = order.OrderReference,
                OrderTotal = order.OrderDetails.Sum(x => x.LineAmount),
                SummaryLines = order.OrderDetails.Select(x => new Models.Endpoints.SummaryLine
                { 
                    ProductName = x.ProductName,
                    LineAmount = x.LineAmount,
                    Quantity = x.Quantity
                })
            };
        }
    }
}
