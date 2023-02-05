using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class SysMailType : BaseEntity
{

    public string MailTypeName { get; set; } = null!;

    public virtual ICollection<GnlUserMailQueue> GnlUserMailQueues { get; } = new List<GnlUserMailQueue>();
}
