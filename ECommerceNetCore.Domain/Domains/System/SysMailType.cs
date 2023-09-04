using ECommerce.Core.Domain;
using ECommerce.User;
using System;
using System.Collections.Generic;

namespace ECommerce.Systems;

public partial class SysMailType : AggregateRoot<int>
{

    public string MailTypeName { get; set; } = null!;

    public virtual ICollection<GnlUserMailQueue> GnlUserMailQueues { get; } = new List<GnlUserMailQueue>();
}
