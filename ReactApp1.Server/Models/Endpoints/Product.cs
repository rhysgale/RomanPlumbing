namespace ReactApp1.Server.Models.Endpoints
{
    public class Product
    {
        public Product(string reference,
            string imageUrl,
            string name,
            string description,
            decimal price
        )
        {
            this.Reference = reference;
            this.ImageUrl = imageUrl;
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        public string ImageUrl { get; private set; }
        public string Reference {  get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; } 
        public decimal Price { get; private set; }
    }
}
