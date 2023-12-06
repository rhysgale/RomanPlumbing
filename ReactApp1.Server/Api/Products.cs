using ReactApp1.Server.Helpers.Api;

namespace ReactApp1.Server.Api
{
    public class Products
    {
        private readonly Models.Database.RetailContext retailContext;

        public Products(Models.Database.RetailContext retailContext)
        {
            this.retailContext = retailContext;    
        }

        public IEnumerable<Models.Api.Product> GetProducts()
        {
            var products = retailContext.Products.ToList();

            // TODO
            return products.Select(product => product.DatabaseProductToApiProduct());
        }

        public bool AddProduct(Models.Api.Product product)
        {
            // TODO: Validate product entries. This is only for initial setup though...

            retailContext.Products.Add(new Models.Database.Product()
            {
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Price = product.Price,
                Reference = product.Reference,
                Sku = product.ProductSku
            });

            return retailContext.SaveChanges() > 0;
        }

        public Models.Api.Product GetProduct(string reference)
        {
            var product = retailContext.Products.FirstOrDefault(x => x.Reference == reference);

            if (product == null)
            {
                throw new Exception("Product does not exist");
            }

            return product.DatabaseProductToApiProduct();
        }
    }
}
