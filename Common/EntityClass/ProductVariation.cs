using System;
using System.Collections.Generic;

namespace Common.EntityClass;

public partial class ProductVariation
{
    public int VariantId { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string Color { get; set; } = null!;

    public double Price { get; set; }

    public int Quantity { get; set; }

    public string Specification { get; set; } = null!;

    public double Discount { get; set; }

    public int BatchNumber { get; set; }

    public virtual Product Product { get; set; } = null!;
}
