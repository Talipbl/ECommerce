using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class SysUnitType :BaseEntity
{

    public string TypeName { get; set; } = null!;

    public virtual ICollection<GnlProductOption> GnlProductOptionUnitTypes { get; } = new List<GnlProductOption>();
}
