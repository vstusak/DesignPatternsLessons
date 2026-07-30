using Microsoft.AspNetCore.Mvc;
using ProductFuriousStore.Contracts.Entities;
using ProductFuriousStore.Logic.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductFuriousStore.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepo productRepo;

        public ProductsController(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepo.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(productRepo.Get(id));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            var newProduct = productRepo.Add(product);
            return CreatedAtAction(nameof(Get), newProduct.Id, newProduct);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            try
            {
                productRepo.Update(product);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                productRepo.Delete(id);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            return NoContent();
        }
    }
}
