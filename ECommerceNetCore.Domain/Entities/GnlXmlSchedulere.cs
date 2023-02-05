using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class GnlXmlSchedulere : BaseEntity
{

    public int? XmlId { get; set; }

    public int? Frequency { get; set; }

    public int? FrequnecyPeriod { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastWorkingTime { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<GnlXmlSchedulereLog> GnlXmlSchedulereLogs { get; } = new List<GnlXmlSchedulereLog>();

    public virtual SysStatusType? Status { get; set; }

    public virtual GnlProductXml? Xml { get; set; }
}
