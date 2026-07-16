using BatchnewB3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BatchnewB3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProducts()
        {

        }
        [HttpGet("{Id}")]
        public IActionResult GetProductById(int Id)
        {
            
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {

        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {

        }
      
        [HttpDelete("{Id}")]
        public IActionResult DeleteProduct(int Id)
        {
        }
    }
}
