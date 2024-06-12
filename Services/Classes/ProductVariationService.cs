using AutoMapper;
using Common.DBEntityClass;
using Common.UpdationModel;
using Common.UserModel;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Classes
{
    public class ProductVariationService : IProductVariationService
    {
        private readonly IProductVariationRepository _repository;
        private readonly IMapper _mapper;
        private readonly ElectronicsStoreContextNew _context;

        public ProductVariationService(IProductVariationRepository repository, IMapper mapper, ElectronicsStoreContextNew context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<ProductVariationUpdationModel>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductVariationUpdationModel>>(entities);
        }

        public async Task<ProductVariationUpdationModel?> GetByIdAsync(int variantId)
        {
            var entity = await _repository.GetByIdAsync(variantId);
            return entity == null ? null : _mapper.Map<ProductVariationUpdationModel>(entity);
        }

        public async Task<(bool Success, string Message)> AddAsync(ProductVariationsModel model)
        {
            if (!await _repository.ProductExistsAsync(model.ProductId))
            {
                return (false, "Product ID does not exist.");
            }

            var entity = _mapper.Map<ProductVariation>(model);

            if (entity.Date == default)
            {
                entity.Date = DateOnly.FromDateTime(DateTime.Now);
            }

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            await UpdateProductQuantity(model.ProductId, entity.Quantity, true);

            return (true, "Product variation added successfully.");
        }

        public async Task<(bool Success, string Message)> UpdateAsync(ProductVariationUpdationModel model)
        {
            if (!await _repository.VariantExistsAsync(model.VariantId))
            {
                return (false, "Variant ID does not exist.");
            }

            if (!await _repository.ProductExistsAsync(model.ProductId))
            {
                return (false, "Product ID does not exist.");
            }

            var entity = await _repository.GetByIdAsync(model.VariantId);
            if (entity == null)
            {
                return (false, "Variant ID does not exist.");
            }

            int quantityChange = model.Quantity;

            entity.Color = model.Color;
            entity.Price = model.Price;
            entity.Quantity += quantityChange;
            entity.Specification = model.Specification;
            entity.Discount = model.Discount;
            entity.BatchNumber = model.BatchNumber;

            
            if (model.Date != default)
            {
                entity.Date = model.Date;
            }

            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();

            await UpdateProductQuantity(model.ProductId, quantityChange, true);

            return (true, "Product variation updated successfully.");
        }

        public async Task<(bool Success, string Message)> DeleteAsync(int variantId)
        {
            var entity = await _repository.GetByIdAsync(variantId);
            if (entity == null)
            {
                return (false, "Variant ID does not exist.");
            }

            await _repository.DeleteAsync(entity);
            await _repository.SaveChangesAsync();
            await UpdateProductQuantity(entity.ProductId, -entity.Quantity, true);

            return (true, "Deletion successful.");
        }

        private async Task UpdateProductQuantity(int productId, int quantityChange, bool addQuantity)
        {
            var product = await _context.Set<Product>().FindAsync(productId);

            if (product != null)
            {
                product.Quantity += addQuantity ? quantityChange : -quantityChange;
                _context.Set<Product>().Update(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
