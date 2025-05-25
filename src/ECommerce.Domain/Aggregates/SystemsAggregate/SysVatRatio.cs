using ECommerce.Domain;
using ECommerce.Product;
using System;
using System.Collections.Generic;

namespace ECommerce.Systems;

public partial class SysVatRatio : AggregateRoot<int>
{

    public decimal VatRatioValue { get; set; }

    public virtual ICollection<GnlProductPrice> GnlProductPrices { get; } = new List<GnlProductPrice>();
}
