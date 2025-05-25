using ECommerce.Domain;
using ECommerce.Product;
using ECommerce.Systems;
using System;
using System.Collections.Generic;

namespace ECommerce.Xml;

public partial class GnlXmlScheduler : AggregateRoot<int>
{

    public int? XmlId { get; set; }

    public int? Frequency { get; set; }

    public int? FrequnecyPeriod { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastWorkingTime { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<GnlXmlSchedulerLog> GnlXmlSchedulerLogs { get; } = new List<GnlXmlSchedulerLog>();

    public virtual SysStatusType? Status { get; set; }

    public virtual GnlProductXml? Xml { get; set; }
}
