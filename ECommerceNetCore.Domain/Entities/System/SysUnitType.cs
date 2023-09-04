using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class SysUnitType :AggregateRoot
{

    public string TypeName { get; set; } = null!;

    public virtual ICollection<GnlProductOption> GnlProductOptionUnitTypes { get; } = new List<GnlProductOption>();
}
