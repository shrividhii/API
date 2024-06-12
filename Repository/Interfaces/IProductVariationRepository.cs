using Common.DBEntityClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IProductVariationRepository
    {
        Task<IEnumerable<ProductVariation>> GetAllAsync();
        Task<ProductVariation?> GetByIdAsync(int variantId);
        Task AddAsync(ProductVariation entity);
        Task UpdateAsync(ProductVariation entity);
        Task DeleteAsync(ProductVariation entity);
        Task<bool> ProductExistsAsync(int productId);
        Task<bool> VariantExistsAsync(int variantId);
        Task SaveChangesAsync();
    }
}
