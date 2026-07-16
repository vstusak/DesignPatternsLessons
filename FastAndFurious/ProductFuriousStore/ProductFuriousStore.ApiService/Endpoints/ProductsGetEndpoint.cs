using ProductFuriousStore.ApiService.Data;

namespace ProductFuriousStore.ApiService;

public class ProductsGetEndpoint : IEndpoint
{
    private readonly ILogger<ProductsGetEndpoint> _logger;
    private readonly IProductRepo _productRepo;

    public ProductsGetEndpoint(ILogger<ProductsGetEndpoint> logger, IProductRepo productRepo)
    {
        _logger = logger;
        _productRepo = productRepo;
    }
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", () =>
            {
                _logger.LogDebug("Fetching all products");
                return _productRepo.GetAll();
            })
            .WithName("GetProducts");
    }
}