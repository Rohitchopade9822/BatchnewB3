using BatchnewB3.Model;
using BatchnewB3.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BatchnewB3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
         _repo= repo;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var data=_repo.GetMethod();
            return Ok(data);

        }
        [HttpGet("{Id}")]
        public IActionResult GetProductById(int Id)
        {
            var data=_repo.GetbyId(Id);
            if(data==null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
          _repo.AddProuduct(product);
            return Ok("Product created successfully");
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            _repo.UpdateProduct(product);
            return Ok("Product updated successfully");
        }
      
        [HttpDelete("{Id}")]
        public IActionResult DeleteProduct(int Id)
        {
            _repo.DeleteProduct(Id);
            return Ok("Product deleted successfully");
        }
    }
}
