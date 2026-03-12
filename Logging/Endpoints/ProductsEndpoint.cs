using ProductStore.Contracts.Model;

namespace ProductStore.WebApi.Endpoints
{
    public class ProductsEndpoint:IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/productsmin", () =>
                {
                    return new Product { Name = "Bota", Price = 99, Quantity = 2 };

                    //_logger.LogDebug($"Get product with '{id}' id");

                    //var product = _productProvider.GetProduct(id);

                    //if (product == null)
                    //{
                    //    _logger.LogWarning($"Cannot find product with '{id}' id");
                    //    return NotFound();
                    //}

                    //return Ok(product);
                }).WithName("GetProductsMinimal")
                .WithDisplayName("Get Products Minimal API")
                .WithDescription("this is our get product minimal API endpoint");
        }
    }

    public interface IEndpoint  
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
}
