using Common.UpdationModel;
using Common.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductUpdationModel>> GetAll();
        Task<ProductModel> GetById(int id);
        Task<string> Add(ProductModel model);
        Task<string> Update(ProductUpdationModel model);
       public void Delete(int id);
    }
}
