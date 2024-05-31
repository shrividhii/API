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

        public string CategoryName { get; set; } = null!;

        public string BrandName { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
