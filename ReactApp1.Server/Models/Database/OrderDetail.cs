namespace ReactApp1.Server.Models.Database
{
    public class OrderDetail
    {
        public int OrderDetailId {  get; set; }

        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string ProductSku { get; set; }
        public decimal LineAmount { get; set; }

        public Order Order { get; set; }
    }
}
