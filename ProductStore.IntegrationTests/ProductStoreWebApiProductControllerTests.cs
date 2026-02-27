using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using Testcontainers;
using Testcontainers.MsSql;
using Xunit;
using Logging.Api;
using Microsoft.EntityFrameworkCore;
using ProductStore.Data;

namespace ProductStore.IntegrationTests
{
    public class ProductStoreWebApiProductControllerTests: IAsyncLifetime    
    {
        private readonly MsSqlContainer _msSqlContainer = new MsSqlBuilder("mcr.microsoft.com/mssql/server:2025-latest").Build();
        private WebApplicationFactory<Program> _factory = null!;
        public HttpClient Client { get; private set; } = null!;


        //TODO: 
        
        public async Task InitializeAsync()
        {
            await _msSqlContainer.StartAsync();

            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // Remove the existing DbContext registration
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType == typeof(DbContextOptions<WarehouseContext>));

                        if (descriptor is not null)
                            services.Remove(descriptor);

                        // Register DbContext pointing at the container
                        services.AddDbContext<WarehouseContext>(options =>
                            options.UseSqlServer(_msSqlContainer.GetConnectionString()));

                        // Apply migrations against the container DB
                        using var scope = services.BuildServiceProvider().CreateScope();
                        var db = scope.ServiceProvider.GetRequiredService<WarehouseContext>();
                        db.Database.Migrate();
                    });
                });

            Client = _factory.CreateClient();
            
        }

        public async Task DisposeAsync()
        {
            Client.Dispose();
            await _factory.DisposeAsync();
            await _msSqlContainer.DisposeAsync().AsTask();
        }
    }
}



// OD PETRA PUCKA:

//using Hangfire;
//using Microsoft.EntityFrameworkCore;
//using Squirrel.DataAccessLayer.Contexts;
//using Squirrel.Migrations;
//using Squirrell.DataAccess.Scaffolder.Migrations;
//using Testcontainers.MsSql;

//namespace Squirrel.API.Tests.SharedInfrastructure.DockerizedDatabase;

//public sealed class SharedDatabaseFixture : IAsyncLifetime
//{
//    public DbContextOptions<Context> DbContextOptions { get; private set; } = null!;

//    public DbContextOptions<InactiveEntitiesContext> InactiveEntitiesContextOptions { get; private set; } = null!;

//    public DbContextOptions<ReadContext> ReadContextOptions { get; private set; } = null!;

//    private readonly MsSqlContainer sqlContainer =
//        new MsSqlBuilder("mcr.microsoft.com/mssql/server:2022-latest").Build();

//    public async ValueTask InitializeAsync()
//    {
//        await this.sqlContainer.StartAsync();

//        var migrationAssembly = typeof(InitialCreate).Assembly.GetName().Name;

//        this.DbContextOptions = new DbContextOptionsBuilder<Context>()
//            .UseSqlServer(this.sqlContainer.GetConnectionString(), b => b
//                .MigrationsAssembly(migrationAssembly))
//            .Options;

//        this.InactiveEntitiesContextOptions = new DbContextOptionsBuilder<InactiveEntitiesContext>()
//            .UseSqlServer(this.sqlContainer.GetConnectionString(), b => b
//                .MigrationsAssembly(migrationAssembly))
//            .Options;

//        this.ReadContextOptions = new DbContextOptionsBuilder<ReadContext>()
//            .UseSqlServer(this.sqlContainer.GetConnectionString(), b => b
//                .MigrationsAssembly(migrationAssembly))
//            .Options;

//        var dbContext = new Context(this.DbContextOptions);
//        var inactiveEntitiesContext = new InactiveEntitiesContext(this.InactiveEntitiesContextOptions);
//        var readContext = new ReadContext(this.ReadContextOptions);

//        await dbContext.Database.MigrateAsync();
//        await inactiveEntitiesContext.Database.MigrateAsync();
//        await readContext.Database.MigrateAsync();

//        await dbContext.DeployAllScriptsAsync();

//        GlobalConfiguration.Configuration.UseSqlServerStorage(this.sqlContainer.GetConnectionString());

//        await dbContext.DisposeAsync();
//        await inactiveEntitiesContext.DisposeAsync();
//        await readContext.DisposeAsync();
//    }

//    public string GetConnectionString() => this.sqlContainer.GetConnectionString();

//    public async ValueTask DisposeAsync() => await this.sqlContainer.DisposeAsync();
//}
 