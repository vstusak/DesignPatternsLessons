using ProductFuriousStore.Logic.Repo;

namespace ProductFuriousStore.ApiService;

public class ProductsGetEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", (ILogger<ProductsGetEndpoint> logger, IProductRepo productRepo) =>
            {
                logger.LogDebug("Fetching all products");
                return productRepo.GetAll();
            })
            .WithName("GetProducts");

        app.MapGet("/product/{id}", (ILogger<ProductsGetEndpoint> logger, IProductRepo productRepo, int id) =>
        {
            logger.LogWarning("Fetching product with id {id}", id);
            return productRepo.Get(id);

        })
        .WithName("GetProduct");
    }
}

// TODO fix GET by ID
// TODO fix namespace mismatch in swagger for GET all