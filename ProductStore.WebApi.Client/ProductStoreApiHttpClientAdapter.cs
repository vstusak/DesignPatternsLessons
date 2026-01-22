using System.Net.Http.Json;
using ProductStore.Contracts.Model;

namespace ProductStore.WebApi.Client;

public interface IProductStoreApiClient
{
    Task<List<Product>> GetFilteredProductsAsync(string filter = "");
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

    public async Task<List<Product>> DeleteByIdAndReloadAsync(int id)
    {
        await httpClient.DeleteAsync($"Product/{id}");

        var response = await httpClient.GetAsync("Product");
        return await response.Content.ReadFromJsonAsync<List<Product>>() ?? [];
    }
}