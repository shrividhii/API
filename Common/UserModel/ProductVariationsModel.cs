using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UserModel
{
    internal class ProductVariationsModel
    {
        public string ProductName { get; set; } = null!;

        public string Color { get; set; } = null!;

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Specification { get; set; } = null!;

        public double Discount { get; set; }

        public int BatchNumber { get; set; }
    }
}
