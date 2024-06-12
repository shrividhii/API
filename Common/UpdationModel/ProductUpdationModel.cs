using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UpdationModel
{
    public class ProductUpdationModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public int Quantity { get; set; }
    }
}
