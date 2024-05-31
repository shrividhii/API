using Common.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Electronics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandModel>>> GetAllBrands()
        {
            var brands = await _brandService.GetAllBrands();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandModel>> GetBrandById(int id)
        {
            var brand = await _brandService.GetBrandById(id);
            if (brand == null)
            {
                return NotFound();
            }
            return brand;
        }

        [HttpPost]
        public async Task<ActionResult<BrandModel>> AddBrand(BrandModel brandModel)
        {
            await _brandService.AddBrand(brandModel);
            return CreatedAtAction(nameof(GetBrandById), new { id = brandModel.BrandId }, brandModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, BrandModel brandModel)
        {
            if (id != brandModel.BrandId)
            {
                return BadRequest();
            }

            await _brandService.UpdateBrand(brandModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandService.DeleteBrand(id);
            return NoContent();
        }
    }
}
