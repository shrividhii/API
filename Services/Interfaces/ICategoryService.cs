using Common.UpdationModel;
using Common.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryUpdationModel>> GetAllCategories();
        Task<CategoryModel> GetCategoryById(int id);
        Task AddCategory(CategoryModel categoryModel);
        Task UpdateCategory(CategoryUpdationModel updateCategoryModel);
        public void DeleteCategory(int id);
    }
}
