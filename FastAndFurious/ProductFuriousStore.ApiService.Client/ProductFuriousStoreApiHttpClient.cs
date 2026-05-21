using Microsoft.Extensions.Logging;
using ProductFuriousStore.Contracts.Entities;
using System.Net.Http.Json;

namespace ProductFuriousStore.ApiService.Client
{
    public class ProductFuriousStoreApiHttpClient(HttpClient client, ILogger<ProductFuriousStoreApiHttpClient> logger) : IProductFuriousStoreApiHttpClient
    {
        public async Task<IList<Product>> GetAllFromController()
        {
            var response = await client.GetAsync("/api/products/");

            try
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<Product>>() ?? [];
            }
            catch(HttpRequestException ex)
            {
                logger.LogError(ex,"request error");
                throw;
            }
        }

        public async Task<IList<Product>> GetAllFromMinimalApi()
        {
            var response = await client.GetAsync("/products/");

            try
            {
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<Product>>() ?? [];
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex, "request error");
                throw;
            }
        }
    }
}
