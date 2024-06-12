using Common.DBEntityClass;
using Common.UpdationModel;
using Common.UserModel;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Classes
{
    public class FilterRepository : IFilterRepository
    {
        private readonly ElectronicsStoreContextNew _context;

        public FilterRepository(ElectronicsStoreContextNew context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BrandModel>> GetAllBrandsAsync()
        {
            var brands = await _context.Brands
                .Select(p => new BrandModel
                {
                    BrandName = p.BrandName
                })
                .ToListAsync();

            return brands;
        }

        public async Task<IEnumerable<object>> GetAllCategoryNamesAsync()
        {
            return await _context.Categories
                .Select(c => new
                {
                    c.CategoryName
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductVariationsModel>> GetByDateAsync(DateOnly date)
        {
            var dateOnly = new DateOnly(date.Year, date.Month, date.Day); 

            var products = await _context.ProductVariations
                .Where(pv => pv.Date == dateOnly)
                .Select(pv => new ProductVariationsModel
                {
                    ProductId = pv.ProductId,
                    Quantity = pv.Quantity,
                    Date = pv.Date
                })
                .ToListAsync();

            return products;
        }
        public async Task<IEnumerable<object>> GetProductsByPriceRangeAsync(double minPrice, double maxPrice)
        {
            var products = await _context.ProductVariations
                .Where(pv => pv.Price >= minPrice && pv.Price <= maxPrice)
                .Select(pv => new
                {
                    pv.ProductId,
                    pv.Color,
                    pv.Price,
                    pv.Specification,
                    pv.Discount,
                    pv.BatchNumber,
                    pv.Product.ProductName,
                    pv.Product.CategoryId,
                    pv.Product.BrandId,
                    pv.Quantity 
                })
                .ToListAsync();

            return products;
        }
    
    }
}

