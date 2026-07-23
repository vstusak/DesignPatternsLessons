using ProductFuriousStore.ApiService.Data;

namespace ProductFuriousStore.ApiService;

public class ProductsDeleteEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id:int}", (int id, IProductRepo productRepo) =>
            {
                productRepo.Delete(id);
                return Results.NoContent();
            })
            .WithName("DeleteProduct");
    }
}