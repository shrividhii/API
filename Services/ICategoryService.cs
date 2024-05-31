using Common.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetAllCategories();
        Task<CategoryModel> GetCategoryByName(string name);
        Task AddCategory(CategoryModel categoryModel);
        Task UpdateCategory(CategoryModel categoryModel);
        Task DeleteCategory(string name);
    }
}
