using Common.UpdationModel;
using Common.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Electronics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationService _service;

        public ProductVariationController(IProductVariationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVariationUpdationModel>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{variantId}")]
        public async Task<ActionResult<ProductVariationUpdationModel>> GetById(int variantId)
        {
            var result = await _service.GetByIdAsync(variantId);
            if (result == null)
            {
                return NotFound("Invalid Variant ID.");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVariationsModel model)
        {
            var (success, message) = await _service.AddAsync(model);
            if (!success)
            {
                return BadRequest(message);
            }
            return CreatedAtAction(nameof(GetById), new { variantId = model.ProductId }, model);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductVariationUpdationModel model)
        {
            var (success, message) = await _service.UpdateAsync(model);
            if (!success)
            {
                return BadRequest(message);
            }
            return NoContent();
        }

        [HttpDelete("{variantId}")]
        public async Task<IActionResult> Delete(int variantId)
        {
            var (success, message) = await _service.DeleteAsync(variantId);
            if (!success)
            {
                return NotFound(message);
            }
            return NoContent();
        }
    }
}
