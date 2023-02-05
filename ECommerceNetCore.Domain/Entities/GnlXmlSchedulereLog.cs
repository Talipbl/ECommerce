using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class GnlXmlSchedulereLog : BaseEntity
{

    public int SchedulereId { get; set; }

    public int XmlId { get; set; }

    public DateTime? WorkedTime { get; set; }

    public bool IsSuccess { get; set; }

    public virtual GnlXmlSchedulere Schedulere { get; set; } = null!;

    public virtual GnlProductXml Xml { get; set; } = null!;
}
