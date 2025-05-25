using ECommerce.Core.Domain;
using System;
using System.Collections.Generic;

namespace ECommerce.Product;

public partial class GnlProductImage : AggregateRoot<int>
{

    public int ProductId { get; set; }

    public int OptionId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual GnlProductOption Option { get; set; } = null!;

    public virtual GnlProduct Product { get; set; } = null!;
}
