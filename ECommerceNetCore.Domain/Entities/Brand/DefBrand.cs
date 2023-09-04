using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class DefBrand : AggregateRoot
{

    public string BrandName { get; set; } = null!;

    public virtual ICollection<GnlProduct> GnlProducts { get; } = new List<GnlProduct>();
}
