using Common.UpdationModel;
using Common.UserModel;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class FilterService : IFilterService
    {
        private readonly IFilterRepository _filterRepository;

        public FilterService(IFilterRepository filterRepository)
        {
            _filterRepository = filterRepository;
        }

        public async Task<IEnumerable<BrandModel>> GetAllBrandsAsync()
        {
            return await _filterRepository.GetAllBrandsAsync();
        }

        public async Task<IEnumerable<object>> GetAllCategoryNamesAsync()
        {
            return await _filterRepository.GetAllCategoryNamesAsync();
        }

        public async Task<IEnumerable<ProductVariationsModel>> GetByDateAsync(DateOnly date)
        {
            return await _filterRepository.GetByDateAsync(date);
        }

        public async Task<IEnumerable<object>> GetProductsByPriceRangeAsync(double minPrice, double maxPrice)
        {
            return await _filterRepository.GetProductsByPriceRangeAsync(minPrice, maxPrice);
        }
    }
}
