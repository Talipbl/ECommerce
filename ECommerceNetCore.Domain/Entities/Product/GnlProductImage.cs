using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class GnlProductImage : AggregateRoot
{

    public int ProductId { get; set; }

    public int OptionId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual GnlProductOption Option { get; set; } = null!;

    public virtual GnlProduct Product { get; set; } = null!;
}
