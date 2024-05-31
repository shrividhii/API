using Common.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Electronics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ProductModel>> GetProductByName(string name)
        {
            var product = await _productService.GetProductByName(name);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<ProductModel>> AddProduct(ProductModel productModel)
        {
            await _productService.AddProduct(productModel);
            return CreatedAtAction(nameof(GetProductByName), new { name = productModel.ProductName }, productModel);
        }

        [HttpPut("{name}")]
        public async Task<IActionResult> UpdateProduct(string name, ProductModel productModel)
        {
            if (name != productModel.ProductName)
            {
                return BadRequest();
            }

            await _productService.UpdateProduct(name, productModel);
            return NoContent();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteProduct(string name)
        {
            await _productService.DeleteProduct(name);
            return NoContent();
        }
    }
}
