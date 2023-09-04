using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class GnlOrderProduct : AggregateRoot
{

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? VatAmount { get; set; }

    public decimal? DiscountAmount { get; set; }

    public virtual GnlOrder Order { get; set; } = null!;

    public virtual GnlProduct Product { get; set; } = null!;
}
