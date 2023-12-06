namespace ReactApp1.Server.Models.Database
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderReference { get; set; }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public IEnumerable<OrderDetail> Details { get; set; }
    }
}
