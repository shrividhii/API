using AutoMapper;
using Common.DBEntityClass;
using Common.UpdationModel;
using Common.UserModel;
using Microsoft.EntityFrameworkCore;
using Repository.Classes;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Classes
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryUpdationModel>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();
            return _mapper.Map<IEnumerable<CategoryUpdationModel>>(categories);
        }

        public async Task<CategoryModel> GetCategoryById(int id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            return _mapper.Map<CategoryModel>(category);
        }

        public async Task AddCategory(CategoryModel categoryModel)
        {
            if (await _categoryRepository.CategoryNameExists(categoryModel.CategoryName))
            {
              
                throw new Exception("Brand name already exists");
               
            }
            var category = _mapper.Map<Category>(categoryModel);
            await _categoryRepository.AddCategory(category);
        }

        public async Task UpdateCategory(CategoryUpdationModel updateCategoryModel)
        {
            var existingCategory = await _categoryRepository.GetCategoryById(updateCategoryModel.CategoryId);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException("Category not found.");
            }

            _mapper.Map(updateCategoryModel, existingCategory);

            try
            {
                await _categoryRepository.UpdateCategory(existingCategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException("The category was modified or deleted since it was loaded.");
            }
        }

        public void DeleteCategory(int id)
        {
             _categoryRepository.DeleteCategory(id);
        }
    }
}
