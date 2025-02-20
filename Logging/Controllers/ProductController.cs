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
        [HttpGet("{category}")]
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

        [HttpGet("Fail/{id:int}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public IActionResult GetWithFail(int id)
        {
            _logger.LogDebug($"Get product with '{id}' id");

            var rand = Random.Shared;
            
            if (rand.Next(1, 10) > 5)
            {
                var product = _productProvider.GetProduct(id);

                if (product == null)
                {
                    _logger.LogWarning($"Cannot find product with '{id}' id");
                    return NotFound();
                }
                return Ok(product);
            }

            throw new NotImplementedException();
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
                //TODO fix the CA2017 error
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
                _logger.LogError("Cannot add/update product.", e);
            }

            return Ok();
        }
    }
}
