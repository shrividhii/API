using Common.UpdationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UserModel
{
    public class ProductModel
    {
        public string ProductName { get; set; } = null!;

        public int CategoryId { get; set; } 

        public int BrandId { get; set; } 
   
        public int Quantity { get; set; }
   
    }
}
