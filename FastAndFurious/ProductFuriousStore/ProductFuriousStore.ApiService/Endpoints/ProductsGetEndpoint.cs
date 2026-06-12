namespace ProductFuriousStore.ApiService;

public class ProductsGetEndpoint : IEndpoint
{
    private readonly ILogger<ProductsGetEndpoint> _logger;

    public ProductsGetEndpoint(ILogger<ProductsGetEndpoint> logger)
    {
        _logger = logger;
    }
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", () =>
            {
                _logger.LogDebug("Fetching all products");
                return Products.Collection;
            })
            .WithName("GetProducts");
    }
}