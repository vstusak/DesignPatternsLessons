using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProductStore.Contracts.Model;
using ProductStore.Data;
using Testcontainers.MsSql;

namespace ProductStoreContainerTestPlayground;

[TestClass]
public class ProductStoreWebApiIntegrationTests
{
    private static MsSqlContainer _sqlContainer;
    private static WebApplicationFactory<Logging.Api.Program> _webApplicationFactory;
    
    [ClassInitialize]
    public static async Task ClassInitialize(TestContext context)
    {
        _sqlContainer = new MsSqlBuilder("mcr.microsoft.com/mssql/server:2022-CU14-ubuntu-22.04")
            .Build();

        await _sqlContainer.StartAsync();

        _webApplicationFactory = new WebApplicationFactory<Logging.Api.Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.RemoveAll(typeof(DbContextOptions<WarehouseContext>));

                    // Replace the connection string with the one from the test container
                    var connectionString = _sqlContainer.GetConnectionString().Replace("Database=master", "Database=StoreDbTest1");
                    services.AddDbContext<WarehouseContext>(options =>
                        options.UseSqlServer(connectionString));

                    //ensure the database is created and seeded
                    var serviceProvider = services.BuildServiceProvider();
                    using var scope = serviceProvider.CreateScope();
                    var dbContext = scope.ServiceProvider.GetRequiredService<WarehouseContext>();
                    dbContext.Database.EnsureCreated();
                    //Seed(dbContext);

                });
            });
        
    }

    private static void Seed(WarehouseContext dbContext)
    {
        if (!dbContext.Products.Any())
        {
            dbContext.Products.AddRange(
                new Product { Name = "Ball", Category = "Toy", Price = 123, Quantity = 10 },
                new Product { Name = "Bear", Category = "Toy", Price = 853, Quantity = 5 },
                new Product { Name = "Mouse", Category = "Animal", Price = 56, Quantity = 20 },
                new Product { Name = "Bear", Category = "Animal", Price = 456, Quantity = 8 });

            dbContext.SaveChanges();
        }
    }
}
