using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using ProductStore.Contracts.Model;

namespace Logging.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly ILogger<IndexModel> _logger;

        private readonly ProductStoreApiHttpClientAdapter _httpClient;

        //private readonly IHttpClientFactory _httpClientFactory;
        public List<Product>? Products { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ProductStoreApiHttpClientAdapter httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
            //_httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            Products = await _httpClient.GetFilteredProductsAsync();
        }

        public async Task OnPostShowFilterAsync(string filter)
        {
            Products = await _httpClient.GetFilteredProductsAsync(filter);
        }

        private async Task LogError(string filter, HttpClient apiClient, HttpResponseMessage response)
        {
            var fullPath = $"{apiClient.BaseAddress}Product/{filter}";
            var details = await response.Content.ReadFromJsonAsync<ProblemDetails>() ?? new ProblemDetails();
            var traceId = details.Extensions["traceId"]?.ToString();
            _logger.LogWarning($"API failure: {fullPath}, Response: {response.StatusCode}, TraceId: {traceId}");
            throw new Exception($"Error occured while getting products with {filter} category");
        }

        public async Task OnGetDeleteAsync(int id)
        {
            _logger.LogInformation($"1-Webapp backend is going to delete id {id} ");
            var apiClient = _httpClientFactory.CreateClient("api");
            await apiClient.DeleteAsync($"Product/{id}");
            var response = await apiClient.GetAsync("Product");
            Products = await response.Content.ReadFromJsonAsync<List<Product>>();
        }
    }
}
