using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class GnlProductCategory : AggregateRoot
{

    public int ProductId { get; set; }

    public int SubCategoryId { get; set; }

    public virtual GnlProduct Product { get; set; } = null!;

    public virtual DefSubCategory SubCategory { get; set; } = null!;
}
