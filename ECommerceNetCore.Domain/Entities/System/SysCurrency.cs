using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class SysCurrency : AggregateRoot
{

    public string CurrencyName { get; set; } = null!;

    public string CurrencyCode { get; set; } = null!;

    public string Icon { get; set; } = null;

    public virtual ICollection<GnlOrderPayment> GnlOrderPayments { get; } = new List<GnlOrderPayment>();

    public virtual ICollection<GnlProductPrice> GnlProductPrices { get; } = new List<GnlProductPrice>();
}
