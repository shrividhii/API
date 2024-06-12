using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UserModel
{
    public class ProductVariationsModel
    {
        public int ProductId { get; set; }

        public string Color { get; set; } = null!;

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Specification { get; set; } = null!;

        public double Discount { get; set; }

        public DateOnly Date { get; set; }

        public int BatchNumber { get; set; }
    }
}
