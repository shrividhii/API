using Common.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductByName(string name);
        Task AddProduct(ProductModel productModel);
        Task UpdateProduct(string name, ProductModel productModel);
        Task DeleteProduct(string name);
    }
}
