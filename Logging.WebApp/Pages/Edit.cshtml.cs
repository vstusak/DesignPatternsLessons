using Logging.WebApp.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductStore.Contracts.Model;
using ProductStore.WebApi.Client;

namespace ProductStore.WebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        //private readonly IHttpClientFactory _httpClientFactory;

        public Product Product { get; set; }

        private readonly IProductStoreApiClient _productStoreApiClient;

        public EditModel(ILogger<EditModel> logger, IProductStoreApiClient productStoreApiClient /*IHttpClientFactory httpClientFactory*/)
        {
            _logger = logger;
            _productStoreApiClient = productStoreApiClient;
        }

        
        public async Task OnGet()
        {

        }

        public async Task OnGetEdit(int id)
        {
            //var apiClient = _httpClientFactory.CreateClient("api");
            //apiClient.BaseAddress = new Uri("https+http://apiservice");
            //var response = await apiClient.GetAsync($"Product/{id}");
            //var response = await apiClient.GetAsync($"Product/FailTwice/{id}");
            //if (response.IsSuccessStatusCode)
            //{
            //    Product = await response.Content.ReadFromJsonAsync<Product>() ?? throw new ArgumentException($"{id} id not found");
            //}
            //else {
            //    throw new Exception($"Api call failed {response.Content}");
            //}
            
            //TODO: Zkontrolovat jestli tam je a pripadne vyhodit defaultni resilience
            
            Product = await _productStoreApiClient.GetProductByIdWithTransientFailureAsync(id) ?? throw new ArgumentException($"{id} id not found");

        }


        public async Task OnPost(Product product)
        {
            //TODO: Dodat do klienta
            //var apiClient = _httpClientFactory.CreateClient("api");
            //apiClient.BaseAddress = new Uri("https+http://apiservice");
            ////var content = New
            //await apiClient.PostAsJsonAsync<Product>("Product/",product);
            //Response.Redirect("/");
        }
    }
}
