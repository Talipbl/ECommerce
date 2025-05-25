using ECommerce.Domain;
using ECommerce.Product;
using System;
using System.Collections.Generic;

namespace ECommerce.Order;

public partial class GnlOrderProduct : AggregateRoot<int>
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
