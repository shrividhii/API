using Common.EntityClass;
using Common.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandModel>> GetAllBrands();
        Task<BrandModel> GetBrandById(int id);
        Task AddBrand(BrandModel brandModel);
        Task UpdateBrand(BrandModel brandModel);
        Task DeleteBrand(int id);
    }
}
