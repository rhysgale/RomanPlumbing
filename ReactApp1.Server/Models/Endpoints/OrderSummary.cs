namespace ReactApp1.Server.Models.Endpoints
{
    public class OrderSummary
    {
        public string OrderReference { get; set; }
        public IEnumerable<SummaryLine> SummaryLines { get; set; }
        public decimal OrderTotal { get; internal set; }
    }

    public class SummaryLine
    {
        public string ProductName { get; set; }
        public decimal LineAmount{ get; set; }
        public int Quantity { get; internal set; }
    }
}
