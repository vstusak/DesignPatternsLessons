using ProductFuriousStore.ApiService.Data;

namespace ProductFuriousStore.ApiService;

public class ProductsGetEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", (ILogger<ProductsGetEndpoint> logger, IProductRepo productRepo) =>
            {
                logger.LogDebug("Fetching all products");
                return productRepo.GetAll();
            })
            .WithName("GetProducts");
    }
}