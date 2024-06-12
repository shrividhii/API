using Common.DBEntityClass;
using Common.UpdationModel;
using Common.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandUpdationModel>> GetAllBrands();
        Task<BrandUpdationModel> GetBrandById(int id);
        Task AddBrand(BrandModel brandModel);
        Task UpdateBrand(BrandUpdationModel brandModel);
        void DeleteBrand(int id);
    }
}
