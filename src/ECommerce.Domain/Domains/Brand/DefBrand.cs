using ECommerce.Core.Domain;
using ECommerce.Product;
using System;
using System.Collections.Generic;

namespace ECommerce.Brand;

public partial class DefBrand : AggregateRoot<int>
{

    public string BrandName { get; set; } = null!;

    public virtual ICollection<GnlProduct> GnlProducts { get; } = new List<GnlProduct>();
}
