﻿using System;
using System.Collections.Generic;

namespace Common.EntityClass;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public int CategoryId { get; set; }

    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductVariation> ProductVariations { get; set; } = new List<ProductVariation>();
}
