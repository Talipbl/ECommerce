using ECommerce.Domain;
using ECommerce.Product;
using System;
using System.Collections.Generic;

namespace ECommerce.Manufacturer;

public partial class DefManufacturer : AggregateRoot<int>
{

    public string ManufacturersName { get; set; } = null!;

    public string? ContacInfo { get; set; }

    public virtual ICollection<GnlProduct> GnlProducts { get; } = new List<GnlProduct>();
}
