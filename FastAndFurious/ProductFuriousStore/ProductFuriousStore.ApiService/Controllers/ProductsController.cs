using Microsoft.AspNetCore.Mvc;
using ProductFuriousStore.Contracts.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductFuriousStore.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
           
            return Products.Collection;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            var newId = Products.Collection.Any() ? Products.Collection.Max(p => p.Id) + 1 : 1;
            var newProduct = product with { Id = newId };
            Products.Collection.Add(newProduct);
            return CreatedAtAction(nameof(Get), new { id = newId }, newProduct);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            var existing = Products.Collection.FirstOrDefault(p => p.Id == product.Id);
            if (existing is null)
            {
                return NotFound();
            }

            var index = Products.Collection.IndexOf(existing);
            Products.Collection[index] = product;
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = Products.Collection.FirstOrDefault(p => p.Id == id);
            if (product is null)
            {
                return NotFound();
            }

            Products.Collection.Remove(product);
            return NoContent();
        }
    }
}
