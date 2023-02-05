using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class GnlUserMailQueue : BaseEntity
{

    public int UserId { get; set; }

    public string NameSurname { get; set; } = null!;

    public string? MailAddress { get; set; }

    public int MailTypeId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? SendDate { get; set; }

    public bool IsSend { get; set; }

    public virtual SysMailType MailType { get; set; } = null!;

    public virtual GnlUser User { get; set; } = null!;
}
