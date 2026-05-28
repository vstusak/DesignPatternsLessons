using System.Net;
using System.Net.Http.Json;
using ProductFuriousStore.Contracts.Entities;
using Xunit;

namespace ProductFuriousStore.ApiService.Tests;

public class ProductsEndpointTests : IClassFixture<ApiServiceWebApplicationFactory>
{
    private readonly HttpClient _client;

    public ProductsEndpointTests(ApiServiceWebApplicationFactory factory)
    {
        Products.Reset();
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetProducts_ReturnsOkWithProductList()
    {
        var response = await _client.GetAsync("/products");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var products = await response.Content.ReadFromJsonAsync<List<Product>>();

        Assert.NotNull(products);
        Assert.Equal(3, products.Count);
        Assert.Equal(new[] { 1, 2, 3 }, products.Select(product => product.Id));
        Assert.All(products, p =>
        {
            Assert.False(string.IsNullOrWhiteSpace(p.Name));
            Assert.True(p.Price > 0);
            Assert.False(string.IsNullOrWhiteSpace(p.Category));
        });
    }

    [Fact]
    public async Task GetApiProducts_ReturnsOkWithProductList()
    {
        var response = await _client.GetAsync("/api/products");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var products = await response.Content.ReadFromJsonAsync<List<Product>>();

        Assert.NotNull(products);
        Assert.Equal(3, products.Count);
        Assert.Equal(new[] { 1, 2, 3 }, products.Select(product => product.Id));
        Assert.All(products, p =>
        {
            Assert.False(string.IsNullOrWhiteSpace(p.Name));
            Assert.True(p.Price > 0);
            Assert.False(string.IsNullOrWhiteSpace(p.Category));
        });
    }

    [Fact]
    public async Task GetApiProductsById_ReturnsOkWithValue()
    {
        var response = await _client.GetAsync("/api/products/1");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var value = await response.Content.ReadAsStringAsync();

        Assert.Equal("value", value);
    }

    [Fact]
    public async Task DeleteProduct_RemovesProductFromStaticCollection()
    {
        var response = await _client.DeleteAsync("/products/2");

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

        var products = await _client.GetFromJsonAsync<List<Product>>("/products");

        Assert.NotNull(products);
        Assert.Equal(2, products.Count);
        Assert.DoesNotContain(products, product => product.Id == 2);
    }
}

/*
 Vytvořil jsem integrační testy. Zde je souhrn:
Vytvořené soubory:
1.	ProductFuriousStore.ApiService.Tests.csproj – testovací projekt s xUnit v3, Microsoft.AspNetCore.Mvc.Testing a referencí na API projekt.
2.	ApiServiceWebApplicationFactory.cs – minimální custom factory odvozená od WebApplicationFactory<Program>, připravená k rozšíření (např. o Testcontainers pro databázi, až bude potřeba).
3.	ProductsEndpointTests.cs – integrační testy pokrývající:
•	GET /products – minimal API endpoint
•	GET /api/products – controller endpoint
•	GET /api/products/{id} – controller endpoint s parametrem
4.	Úprava Program.cs – přidán public partial class Program; pro přístup z testovacího projektu.
Poznámka k Testcontainers: Aktuálně API vrací hardcoded data bez databáze, takže Testcontainers není potřeba (YAGNI). Jakmile přidáte databázi, stačí v ApiServiceWebApplicationFactory přepsat ConfigureWebHost a nastartovat kontejner s DB přes Testcontainers.
Projekt je potřeba přidat do solution (dotnet sln add) aby se zobrazil v Test Exploreru.

*/
