using AutoMapper;
using Common.EntityClass;
using Common.Mail;
using Common.UpdationModel;
using Common.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Classes;
using Services.Interfaces;

namespace Electronics.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryUpdationModel>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryModel>> GetCategoryById(int id)
        {
            var categoryModel = await _categoryService.GetCategoryById(id);
            if (categoryModel == null)
            {
                return NotFound("Invalid ID");
            }
            return Ok(categoryModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory(CategoryModel categoryModel)
        {
            await _categoryService.AddCategory(categoryModel);
            return Ok("Category added successfully");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategory(CategoryUpdationModel CategoryModel)
        {
            if (CategoryModel.CategoryId <= 0)
            {
                return BadRequest(new { message = "Invalid category ID." });
            }

            try
            {
                await _categoryService.UpdateCategory(CategoryModel);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Category not found." });
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "The category was modified or deleted since it was loaded." });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);
                return Ok(new { message = "Category deleted successfully" });
            }
            catch (Exception)
            {
                return BadRequest("Category not found");
            }
            //var existingCategory = await _categoryService.GetCategoryById(id);
            //if (existingCategory == null)
            //{
            //    return NotFound("Invalid ID");
            //}

            //_categoryService.DeleteCategory(id);
            //return Ok("Category deleted successfully");
        }
    }
}
