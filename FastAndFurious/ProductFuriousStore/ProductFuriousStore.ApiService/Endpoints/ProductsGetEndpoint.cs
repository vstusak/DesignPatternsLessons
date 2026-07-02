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
                _logger.LogWarning("Fetching all products");
                return Products.Collection;
            })
            .WithName("GetProducts");

            app.MapGet("/product/{id}", (int id) =>
            {
              //  _logger.LogWarning("Fetching product at index {id}", id);
                return Products.Collection.FirstOrDefault(p => p.Id == id);
            })
            .WithName("GetProduct");
    }
}

// TODO fix GET by ID
// TODO fix namespace mismatch in swagger for GET all