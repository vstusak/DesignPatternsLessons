using ProductFuriousStore.ApiService.Data;

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