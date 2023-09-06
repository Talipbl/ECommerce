using ECommerce.Core.Domain;
using ECommerce.DiscountCoupon;
using ECommerce.Product;
using System;
using System.Collections.Generic;

namespace ECommerce.Category;

public partial class DefCategory : AggregateRoot<int>
{

    public string CategoryName { get; set; } = null!;

    public string? Descriptipn { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<DefDiscountCoupon> DefDiscountCoupons { get; } = new List<DefDiscountCoupon>();

    public virtual ICollection<GnlProduct> GnlProducts { get; } = new List<GnlProduct>();
}
