namespace ReactApp1.Server.Models.Endpoints
{
    public class OrderSummary
    {
        public string OrderReference { get; set; }
        public string ProductName { get; set; }
        public decimal TotalCost { get; set; }
    }
}
