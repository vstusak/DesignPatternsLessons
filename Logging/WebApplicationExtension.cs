using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Logging.Data;

public static class WebApplicationExtension
{
    public static async Task ConfigureDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetService<WarehouseContext>();

        await EnsureDatabaseAsync(dbContext);
        // TODO uncomment when migration is ready
        // await RunMigrationAsync(dbContext);
    }

    private static async Task EnsureDatabaseAsync(WarehouseContext context)
    {
        var dbCreator = context.GetService<IRelationalDatabaseCreator>();
        var strategy = context.Database.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            if (!await dbCreator.ExistsAsync())
            {
                await dbCreator.CreateAsync();
            }
        });

    }

    private static async Task RunMigrationAsync(WarehouseContext context)
    {
        var strategy = context.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            await context.Database.MigrateAsync();
            await transaction.CommitAsync();
        });
    }
}