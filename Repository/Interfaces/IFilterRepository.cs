﻿using Common.UpdationModel;
using Common.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IFilterRepository
    {
        Task<IEnumerable<BrandModel>> GetAllBrandsAsync();
        Task<IEnumerable<object>> GetAllCategoryNamesAsync();
        Task<IEnumerable<ProductVariationsModel>> GetByDateAsync(DateOnly date);
        Task<IEnumerable<object>> GetProductsByPriceRangeAsync(double minPrice, double maxPrice);
    }
}
