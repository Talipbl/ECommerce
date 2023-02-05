using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class DefManufacturer : BaseEntity
{

    public string ManufacturersName { get; set; } = null!;

    public string? ContacInfo { get; set; }

    public virtual ICollection<GnlProduct> GnlProducts { get; } = new List<GnlProduct>();
}
