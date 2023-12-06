using ReactApp1.Server.Models.Database;

namespace ReactApp1.Server.Models.Api
{
    public class Order
    {
        public string OrderReference { get; set; }

        public Api.Address Address { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
