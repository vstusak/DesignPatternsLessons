using Logging.Data.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Logging.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _apiClient;
        public List<Product>? Products { get; set; }

        public IndexModel(ILogger<IndexModel> logger, HttpClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
            _apiClient.BaseAddress = new Uri("https://localhost:7055/");
        }

        public async Task OnGetAsync()
        {
            var response = await _apiClient.GetAsync("product");
            Products = await response.Content.ReadFromJsonAsync<List<Product>>();
        }
    }
}
