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
    public class FilterController : ControllerBase
    {
        private readonly IFilterService _filterService;

        public FilterController(IFilterService filterService)
        {
            _filterService = filterService;
        }

        [HttpGet("ByBrands")]
        public async Task<ActionResult<IEnumerable<BrandModel>>> GetByBrand()
        {
            var products = await _filterService.GetAllBrandsAsync();
            return Ok(products);
        }

        [HttpGet("ByCategory")]
        public async Task<ActionResult<IEnumerable<object>>> GetByCategory()
        {
            var categories = await _filterService.GetAllCategoryNamesAsync();
            return Ok(categories);
        }

        [HttpGet("ByDate(YYYY-MM-DD)")]
        public async Task<ActionResult<IEnumerable<ProductVariationsModel>>> GetByDate(DateOnly date)
        {
            var products = await _filterService.GetByDateAsync(date);
            return Ok(products);
        }
        [HttpGet("ByPriceRange")]
        public async Task<ActionResult<IEnumerable<object>>> GetByPriceRange(double minPrice, double maxPrice)
        {
            var products = await _filterService.GetProductsByPriceRangeAsync(minPrice, maxPrice);
            return Ok(products);
        }

       
    }
}
