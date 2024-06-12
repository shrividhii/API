using AutoMapper;
using Common.Mail;
using Common.UpdationModel;
using Common.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Classes;
using Services.Interfaces;

namespace Electronics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductUpdationModel>>> GetAll()
        {
            var products = await _service.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetById(int id)
        {
            var product = await _service.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductModel model)
        {
            var result = await _service.Add(model);
            if (result == "Product added successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductUpdationModel model)
        {
            var result = await _service.Update(model);
            if (result == "Product updated successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok(new { message = "Product deleted successfully" });
            }
            catch (Exception)
            {
                return BadRequest("Product not found");
            }
        }
    }
}
