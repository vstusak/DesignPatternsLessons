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
        private readonly IProductProvider _productProvider;

        public ProductController(ILogger<ProductController> logger, IProductProvider productProvider)
        {
            _logger = logger;
            _productProvider = productProvider;
        }

        [HttpGet]
        public IEnumerable<Product> Get(string category = "All")
        {
            _logger.LogInformation($"Called product get with '{category}' category");
            return _productProvider.GetProductsForCategory(category);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            _logger.LogDebug($"Get product with '{id}' id");

            var product = _productProvider.GetProduct(id);

            if (product == null)
            {
                _logger.LogWarning($"Cannot find product with '{id}' id");
                return NotFound();
            }

            return Ok(product);
        }
    }
}
