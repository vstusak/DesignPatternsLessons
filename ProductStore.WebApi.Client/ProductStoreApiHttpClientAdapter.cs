using System.Net;
using System.Net.Http.Json;
using ProductStore.Contracts.Model;

namespace ProductStore.WebApi.Client;

public interface IProductStoreApiClient
{
    Task<List<Product>> GetFilteredProductsAsync(string filter = "");
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product?> GetProductByIdWithTransientFailureAsync(int id);
    Task<List<Product>> DeleteByIdAndReloadAsync(int id);
}

public class ProductStoreApiClient(HttpClient httpClient) : IProductStoreApiClient
{
    public async Task<List<Product>> GetFilteredProductsAsync(string filter = "")
    {
        var response = await httpClient.GetAsync($"Product/{filter}");
        try
        {
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Product>>() ?? [];
        }
        catch (Exception e)
        {
            // await LogError(filter, apiClient, response);
            throw;
        }
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await GetProductAsync($"Product/{id}");
    }

    public async Task<Product?> GetProductByIdWithTransientFailureAsync(int id)
    {
        return await GetProductAsync($"Product/FailTwice/{id}");
    }

    private async Task<Product?> GetProductAsync(string requestUri)
    {
        var response = await httpClient.GetAsync(requestUri);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Product>();
    }

    public async Task<List<Product>> DeleteByIdAndReloadAsync(int id)
    {
        await httpClient.DeleteAsync($"Product/{id}");

        var response = await httpClient.GetAsync("Product");
        return await response.Content.ReadFromJsonAsync<List<Product>>() ?? [];
    }
}