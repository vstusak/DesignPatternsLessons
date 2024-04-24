using Logging.Domain;
using Logging.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Logging.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        
        private readonly ILogger<ProductController> _logger;
        

        public ProductController(ILogger<ProductController> logger)
        {
            
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get(string category = "All")
        {
            return _productProvider.Get(category);
        }
    }
}
