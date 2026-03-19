using ProductStore.Contracts.Model;
using ProductStore.Domain;

namespace ProductStore.WebApi.Endpoints
{
    public class ProductsEndpoint(ILogger<ProductsEndpoint> logger, IProductProvider productProvider):IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/productsmin", () =>
                {
                    logger.LogDebug($"Get all products");

                    var products = productProvider.GetProductsForCategory("All");

                    //if (products == null)
                    //{
                    //    logger.LogWarning($"Cannot find products");
                    //    return NotFound();
                    //}

                    return products;
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
