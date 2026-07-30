using ProductFuriousStore.ApiService.Data;
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
        app.MapPut("/products", (Product product, IProductRepo productRepo) =>
            {
                productRepo.Update(product);
                return Results.NoContent();
            })
            .WithName("UpdateProduct");
    }
}