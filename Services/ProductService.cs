using AutoMapper;
using Common.EntityClass;
using Common.UserModel;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductModel>>(products);
        }

        public async Task<ProductModel> GetProductByName(string name)
        {
            var product = await _productRepository.GetProductByName(name);
            return _mapper.Map<ProductModel>(product);
        }

        public async Task AddProduct(ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);
            await _productRepository.AddProduct(product);
        }

        public async Task UpdateProduct(string name, ProductModel productModel)
        {
            var existingProduct = await _productRepository.GetProductByName(name);
            if (existingProduct == null)
            {
                // Handle not found
                return;
            }

            _mapper.Map(productModel, existingProduct);
            await _productRepository.UpdateProduct(existingProduct);
        }

        public async Task DeleteProduct(string name)
        {
            await _productRepository.DeleteProduct(name);
        }
    }
}
