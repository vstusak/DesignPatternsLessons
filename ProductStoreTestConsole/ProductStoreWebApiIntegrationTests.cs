using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProductStore.Contracts.Model;
using ProductStore.Data;
using ProductStore.WebApi.Client;
using System.Net;
using System.Net.Http.Json;
using Testcontainers.MsSql;

namespace ProductStoreContainerTestPlayground;

[TestClass]
public class ProductStoreWebApiIntegrationTests
{
    public TestContext TestContext { get; set; }

    private static MsSqlContainer _sqlContainer;
    private static WebApplicationFactory<Logging.Api.Program> _webApplicationFactory;
    private static HttpClient _client;
    private ProductStoreApiClient _productStoreApiClient;

    // TODO: update aspire to latest version

    [ClassInitialize]
    public static async Task ClassInitialize(TestContext context)
    {
        _sqlContainer = new MsSqlBuilder("mcr.microsoft.com/mssql/server:2022-CU14-ubuntu-22.04")
            .Build();

        await _sqlContainer.StartAsync(context.CancellationToken);

        _webApplicationFactory = new WebApplicationFactory<Logging.Api.Program>()
            .WithWebHostBuilder(builder =>
            {
                Environment.SetEnvironmentVariable("TEST_RUNNING", "true");
                builder.ConfigureServices(async services =>
                {
                    services.RemoveAll(typeof(DbContextOptions<WarehouseContext>));

                    // Replace the connection string with the one from the test container
                    var connectionString = _sqlContainer.GetConnectionString().Replace("Database=master", "Database=StoreDbTest1");
                    services.AddDbContext<WarehouseContext>(options =>
                        options.UseSqlServer(connectionString));
                    // following did nto work, must be in Test initialize
                    //ensure the database is created and seeded
                    //var serviceProvider = services.BuildServiceProvider();
                    //using var scope = serviceProvider.CreateScope();
                    //var dbContext = scope.ServiceProvider.GetRequiredService<WarehouseContext>();
                    //await dbContext.Database.EnsureCreatedAsync();
                    //Seed(dbContext);
                });
            });
        
    }

    [TestInitialize]
    public async Task TestInitialize()
    {
        _client = _webApplicationFactory.CreateClient();
        _productStoreApiClient = new ProductStoreApiClient(_client);
        using var scope = _webApplicationFactory.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<WarehouseContext>();
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();
        await dbContext.SeedAsync(TestContext.CancellationToken);
    }

    [TestCleanup]
    public void TestCleanup()
    {
        _client.Dispose();
    }

    [ClassCleanup]
    public static async Task ClassCleanup()
    {
        await _webApplicationFactory.DisposeAsync();
        await _sqlContainer.DisposeAsync();
    }

    [TestMethod]
    public async Task GetProducts_ShouldReturnAllProducts()
    {
        // Act
        var responseMin = await _client.GetAsync("/productsmin", TestContext.CancellationToken);
        //var response = await _client.GetAsync("/product", TestContext.CancellationToken);

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, responseMin.StatusCode);
        Assert.IsNotNull(responseMin.Content);
        var products = await responseMin.Content.ReadFromJsonAsync<List<Product>>(TestContext.CancellationToken);
        Assert.IsNotNull(products);
        Assert.AreEqual(4, products.Count);
    }

    [TestMethod]
    public async Task GetProducts_ShouldReturnAllProducts_UsingOurProductStoreApiClient()
    {
        // Act
        var products = await _productStoreApiClient.GetFilteredProductsAsync();

        // Assert
        Assert.IsNotNull(products);
        Assert.AreEqual(4, products.Count);
    }
}
