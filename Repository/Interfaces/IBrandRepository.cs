using Common.DBEntityClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllBrands();
        Task<Brand> GetBrandById(int id);
        Task AddBrand(Brand brand);
        Task UpdateBrand(Brand brand);
        public void DeleteBrand(int id);
        Task<bool> BrandExists(int id);
        Task<bool> BrandNameExists(string brandName);
    }
}
