using ECommerce.Domain;
using ECommerce.Category;
using System;
using System.Collections.Generic;

namespace ECommerce.Product;

public partial class GnlProductCategory : AggregateRoot<int>
{

    public int ProductId { get; set; }

    public int SubCategoryId { get; set; }

    public virtual GnlProduct Product { get; set; } = null!;

    public virtual DefSubCategory SubCategory { get; set; } = null!;
}
