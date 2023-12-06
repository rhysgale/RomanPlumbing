namespace ReactApp1.Server.Helpers.Api
{
    public static class ProductHelpers
    {
        public static Models.Endpoints.Product ApiProductToEndpointProduct(this Models.Api.Product apiProduct)
        {
            return new Models.Endpoints.Product (
                apiProduct.Reference,
                apiProduct.ImageUrl,
                apiProduct.Name,
                apiProduct.Description,
                apiProduct.Price
            );
        }

        public static Models.Api.Product DatabaseProductToApiProduct(this Models.Database.Product databaseProduct) 
        {
            return new Models.Api.Product()
            {
                Description = databaseProduct.Description,
                ImageUrl = databaseProduct.ImageUrl,
                Name = databaseProduct.Name,
                Price = databaseProduct.Price,
                Reference = databaseProduct.Reference,
                ProductSku = databaseProduct.Sku
            };
        }
    }
}
