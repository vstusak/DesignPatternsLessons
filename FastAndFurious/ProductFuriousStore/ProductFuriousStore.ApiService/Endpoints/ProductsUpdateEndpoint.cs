using ProductFuriousStore.Contracts.Entities;

namespace ProductFuriousStore.ApiService;

public class ProductsUpdateEndpoint : IEndpoint
{
    private readonly ILogger<ProductsUpdateEndpoint> _logger;

    public ProductsUpdateEndpoint(ILogger<ProductsUpdateEndpoint> logger)
    {
        _logger = logger;
    }
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", (Product product) =>
            {
                var existing = Products.Collection.FirstOrDefault(p => p.Id == product.Id);
                if (existing is null)
                {
                    return Results.NotFound();
                }
                var index = Products.Collection.IndexOf(existing);
                Products.Collection[index] = product;
                return Results.NoContent();
            })
            .WithName("UpdateProduct");
    }
}