using Common.UpdationModel;
using Common.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductVariationService
    {
        Task<IEnumerable<ProductVariationUpdationModel>> GetAllAsync();
        Task<ProductVariationUpdationModel?> GetByIdAsync(int variantId);
        Task<(bool Success, string Message)> AddAsync(ProductVariationsModel model);
        Task<(bool Success, string Message)> UpdateAsync(ProductVariationUpdationModel model);
        Task<(bool Success, string Message)> DeleteAsync(int variantId);
    }
}
