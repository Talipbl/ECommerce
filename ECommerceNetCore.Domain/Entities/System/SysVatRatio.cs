using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class SysVatRatio : AggregateRoot
{

    public decimal VatRatioValue { get; set; }

    public virtual ICollection<GnlProductPrice> GnlProductPrices { get; } = new List<GnlProductPrice>();
}
