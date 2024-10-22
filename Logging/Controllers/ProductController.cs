using Logging.Data.Api.Model;
using Logging.Domain;
using Microsoft.AspNetCore.Mvc;
using ProductStore.Domain;

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

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _logger.LogDebug($"2-Trying to delete product '{id}'.");

            try
            {
                _productProvider.DeleteProduct(id);
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot delete product '{id}'.", e);
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Product product)
        { 
            _logger.LogDebug($"2-Trying to add/update product.");

            try
            {
                _productProvider.AddOrUpdateProduct(product);
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot add/update product.", e);
            }

            return Ok();
        }
    }
}
