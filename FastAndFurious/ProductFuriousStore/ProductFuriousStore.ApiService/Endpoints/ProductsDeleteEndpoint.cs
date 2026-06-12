namespace ProductFuriousStore.ApiService;

public class ProductsDeleteEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id:int}", (int id) =>
            {
                var product = Products.Collection.FirstOrDefault(product => product.Id == id);

                if (product is null)
                {
                    return Results.NotFound();
                }

                Products.Collection.Remove(product);
                return Results.NoContent();
            })
            .WithName("DeleteProduct");
    }
}