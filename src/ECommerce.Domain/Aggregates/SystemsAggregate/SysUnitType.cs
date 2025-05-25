using ECommerce.Domain;
using ECommerce.Product;
using System;
using System.Collections.Generic;

namespace ECommerce.Systems;

public partial class SysUnitType :AggregateRoot<int>
{

    public string TypeName { get; set; } = null!;

    public virtual ICollection<GnlProductOption> GnlProductOptionUnitTypes { get; } = new List<GnlProductOption>();
}
