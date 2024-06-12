using Common.DBEntityClass;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Classes
{
    public class ProductVariationRepository : IProductVariationRepository
    {
        private readonly ElectronicsStoreContextNew _context;

        public ProductVariationRepository(ElectronicsStoreContextNew context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductVariation>> GetAllAsync()
        {
            return await _context.Set<ProductVariation>().ToListAsync();
        }

        public async Task<ProductVariation?> GetByIdAsync(int variantId)
        {
            return await _context.Set<ProductVariation>().FindAsync(variantId);
        }

        public async Task AddAsync(ProductVariation entity)
        {
            await _context.Set<ProductVariation>().AddAsync(entity);
        }

        public async Task UpdateAsync(ProductVariation entity)
        {
            _context.Set<ProductVariation>().Update(entity);
        }

        public async Task DeleteAsync(ProductVariation entity)
        {
            _context.Set<ProductVariation>().Remove(entity);
        }

        public async Task<bool> ProductExistsAsync(int productId)
        {
            return await _context.Set<Product>().AnyAsync(p => p.ProductId == productId);
        }

        public async Task<bool> VariantExistsAsync(int variantId)
        {
            return await _context.Set<ProductVariation>().AnyAsync(v => v.VariantId == variantId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
