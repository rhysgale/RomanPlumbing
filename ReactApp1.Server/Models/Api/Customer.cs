namespace ReactApp1.Server.Models.Api
{
    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Address Address { get; set; }
        public Card Card { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string County { get; set; }
    }

    public class Card
    {
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string ExpMonth { get; set; }
        public string ExpYear { get; set; }
    }
}
