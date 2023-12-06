namespace ReactApp1.Server.Models.Database
{
    public class Product
    {
        public int ProductId { get; set; } 
        public string ImageUrl { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public decimal Price { get; set; }
    }
}
