using Logging.Data.Api.Model;
using Logging.WebApp.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProductStore.WebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public Product Product { get; set; }

        public EditModel(ILogger<EditModel> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        public async Task OnGet(int id)
        {
            var apiClient = _httpClientFactory.CreateClient("api");
            apiClient.BaseAddress = new Uri("https://localhost:7055/");
            var response = await apiClient.GetAsync($"Product/{id}");
            Product = await response.Content.ReadFromJsonAsync<Product>() ?? throw new ArgumentException($"{id} id not found");
        }
    }
}
