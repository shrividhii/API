using Common.EntityClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductByName(string name);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(string name);
    }
}
