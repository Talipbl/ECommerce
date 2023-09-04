using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class DefCategory : AggregateRoot
{

    public string CategoryName { get; set; } = null!;

    public string? Descriptipn { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<DefDiscountCoupon> DefDiscountCoupons { get; } = new List<DefDiscountCoupon>();

    public virtual ICollection<GnlProduct> GnlProducts { get; } = new List<GnlProduct>();
}
