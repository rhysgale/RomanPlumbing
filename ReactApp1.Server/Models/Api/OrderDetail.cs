namespace ReactApp1.Server.Models.Api
{
    public class OrderDetail
    {
        public string ProductName { get; set; }
        public decimal LineAmount { get; set; }
        public int Quantity { get; internal set; }
    }
}
