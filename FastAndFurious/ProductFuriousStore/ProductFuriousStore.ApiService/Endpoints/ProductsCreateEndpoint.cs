using ProductFuriousStore.Contracts.Entities;

namespace ProductFuriousStore.ApiService;

public class ProductsCreateEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", (Product product) =>
            {
                var newId = Products.Collection.Any() ? Products.Collection.Max(p => p.Id) + 1 : 1;
                var newProduct = product with { Id = newId };
                Products.Collection.Add(newProduct);
                return Results.Created($"/products/{newId}", newProduct);
            })
            .WithName("CreateProduct");
    }
}