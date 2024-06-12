using AutoMapper;
using Common.DBEntityClass;
using Common.UpdationModel;
using Common.UserModel;
using Repository.Interfaces;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;

        public ProductService(IProductRepository repository, ICategoryRepository categoryRepository, IBrandRepository brandRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }

        public async Task<IEnumerable<ProductUpdationModel>> GetAll()
        {
            var products = await _repository.GetAll();
            return products.Select(p => new ProductUpdationModel
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId,
                Quantity = p.Quantity
            });
        }

        public async Task<ProductModel> GetById(int id)
        {
            var product = await _repository.GetById(id);
            if (product == null) return null;

            return new ProductModel
            {
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                BrandId = product.BrandId,
                Quantity = product.Quantity
            };
        }

        public async Task<string> Add(ProductModel model)
        {
            if (!await _categoryRepository.CategoryExists(model.CategoryId))
                return "Invalid CategoryId";

            if (!await _brandRepository.BrandExists(model.BrandId))
                return "Invalid BrandId";

            if (await _repository.ProductNameExists(model.ProductName))
                return "Product name already exists";

            var product = new Product
            {
                ProductName = model.ProductName,
                CategoryId = model.CategoryId,
                BrandId = model.BrandId,
                Quantity = model.Quantity
            };

            await _repository.Add(product);
            await _repository.Save();
            return "Product added successfully";
        }

        public async Task<string> Update(ProductUpdationModel model)
        {
            if (!await _categoryRepository.CategoryExists(model.CategoryId))
                return "Invalid CategoryId";

            if (!await _brandRepository.BrandExists(model.BrandId))
                return "Invalid BrandId";

            var product = await _repository.GetById(model.ProductId);
            if (product != null)
            {
                product.ProductName = model.ProductName;
                product.CategoryId = model.CategoryId;
                product.BrandId = model.BrandId;
                product.Quantity = model.Quantity;

                await _repository.Update(product);
                await _repository.Save();
                return "Product updated successfully";
            }
            return "Product not found";
        }

        public void Delete(int id)
        {
             _repository.Delete(id);
            
        }
    }
}
