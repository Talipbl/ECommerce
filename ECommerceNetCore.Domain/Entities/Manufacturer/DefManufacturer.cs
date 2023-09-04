using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class DefManufacturer : AggregateRoot
{

    public string ManufacturersName { get; set; } = null!;

    public string? ContacInfo { get; set; }

    public virtual ICollection<GnlProduct> GnlProducts { get; } = new List<GnlProduct>();
}
