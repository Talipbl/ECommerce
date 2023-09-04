using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class SysMailType : AggregateRoot
{

    public string MailTypeName { get; set; } = null!;

    public virtual ICollection<GnlUserMailQueue> GnlUserMailQueues { get; } = new List<GnlUserMailQueue>();
}
