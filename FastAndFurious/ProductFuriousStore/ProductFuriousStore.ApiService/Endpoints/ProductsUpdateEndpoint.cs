using ProductFuriousStore.ApiService.Data;
using ProductFuriousStore.Contracts.Entities;

namespace ProductFuriousStore.ApiService;

public class ProductsUpdateEndpoint : IEndpoint
{
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