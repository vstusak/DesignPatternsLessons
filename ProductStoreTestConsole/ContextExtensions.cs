using Microsoft.EntityFrameworkCore;
using ProductStore.Contracts.Model;
using ProductStore.Data;

namespace ProductStoreContainerTestPlayground;

public static class ContextExtensions
{
    public static async Task SeedAsync(this WarehouseContext dbContext, CancellationToken ct)
    {
        if (!await dbContext.Products.AnyAsync())
        {
            dbContext.Products.AddRange(
                new Product { Name = "Ball", Category = "Toy", Price = 123, Quantity = 10 },
                new Product { Name = "Bear", Category = "Toy", Price = 853, Quantity = 5 },
                new Product { Name = "Mouse", Category = "Animal", Price = 56, Quantity = 20 },
                new Product { Name = "Bear", Category = "Animal", Price = 456, Quantity = 8 });

            await dbContext.SaveChangesAsync(ct);
        }
    }
}
