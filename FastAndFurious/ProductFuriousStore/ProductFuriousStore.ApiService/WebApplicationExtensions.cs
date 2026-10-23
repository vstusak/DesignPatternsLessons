
using ProductFuriousStore.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ProductFuriousStore.ApiService;

public static class WebApplicationExtensions
{
    public static async Task ConfigureDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ProductStoreContext>();
        await EnsureDatabaseAsync(dbContext);
        await RunMigrationsAsync(dbContext);
    }

    private static async Task EnsureDatabaseAsync(ProductStoreContext dbContext)
    {
        var dbCreator = dbContext.GetService<IRelationalDatabaseCreator>();
        var strategy = dbContext.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            if (!await dbCreator.ExistsAsync())
            {
                await dbCreator.CreateAsync();
            }
        });
    }

    private static async Task RunMigrationsAsync(ProductStoreContext dbContext)
    {
        var strategy = dbContext.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await dbContext.Database.BeginTransactionAsync();
            await dbContext.Database.MigrateAsync();
            await transaction.CommitAsync();
        });
    }
}
