using System;
using System.Collections.Generic;

namespace Common.DBEntityClass;

public partial class ProductVariation
{
    public int VariantId { get; set; }

    public int ProductId { get; set; }

    public string Color { get; set; } = null!;

    public double Price { get; set; }

    public int Quantity { get; set; }

    public string Specification { get; set; } = null!;

    public double Discount { get; set; }

    public int BatchNumber { get; set; }
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public virtual Product Product { get; set; } = null!;
}
