using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class DefSubCategory : AggregateRoot
{

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public int ParentId { get; set; }

    public bool? IsParent { get; set; }

    public virtual ICollection<DefDiscountCoupon> DefDiscountCoupons { get; } = new List<DefDiscountCoupon>();

    public virtual ICollection<GnlProductCategory> GnlProductCategories { get; } = new List<GnlProductCategory>();
}
