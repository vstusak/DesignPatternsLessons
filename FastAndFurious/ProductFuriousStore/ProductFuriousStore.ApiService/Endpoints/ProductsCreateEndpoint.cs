using ProductFuriousStore.ApiService.Data;
using ProductFuriousStore.Contracts.Entities;

namespace ProductFuriousStore.ApiService;

public class ProductsCreateEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", (Product product, IProductRepo productRepo) =>
            {
                var createdProduct = productRepo.Add(product);
                return Results.Created($"/products/{createdProduct.Id}", createdProduct);
            })
            .WithName("CreateProduct");
    }
}