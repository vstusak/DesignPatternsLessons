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
            return new List<Product>()
            {
                new()
                {
                    Name = "Product 10",
                    Category = "Category 10",
                    Price = 10
                },
                new()
                {
                    Name = "Product 20",
                    Category = "Category 20",
                    Price = 20
                },
                new()
                {
                    Name = "Product 30",
                    Category = "Category 30",
                    Price = 30
                }
            };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
