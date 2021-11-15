using Domain.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (!result.Success) return BadRequest(result.Message);

            return Ok(result);
        }
        
        [HttpGet("GetListByCategory")]
        public IActionResult GetListByCategory(int categoryId)
        {
            var result = _productService.GetListByCategory(categoryId);
            if (!result.Success) return BadRequest(result.Message);

            return Ok(result);
        }
        
        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var result = _productService.GetList();
            if (!result.Success) return BadRequest(result.Message);

            return Ok(result);
        }
        
        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (!result.Success) return BadRequest(result.Message);

            return Ok(result);
        }
        
        [HttpPost("Update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (!result.Success) return BadRequest(result.Message);

            return Ok(result);
        }
        
        [HttpPost("Delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (!result.Success) return BadRequest(result.Message);

            return Ok(result);
        }
    }
}