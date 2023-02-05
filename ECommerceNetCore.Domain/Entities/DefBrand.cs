using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class DefBrand : BaseEntity
{

    public string BrandName { get; set; } = null!;

    public virtual ICollection<GnlProduct> GnlProducts { get; } = new List<GnlProduct>();
}
