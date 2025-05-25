using ECommerce.Core.Domain;
using ECommerce.Product;
using System;
using System.Collections.Generic;

namespace ECommerce.Xml;

public partial class GnlXmlSchedulerLog : AggregateRoot<int>
{

    public int SchedulereId { get; set; }

    public int XmlId { get; set; }

    public DateTime? WorkedTime { get; set; }

    public bool IsSuccess { get; set; }

    public virtual GnlXmlScheduler Scheduler { get; set; } = null!;

    public virtual GnlProductXml Xml { get; set; } = null!;
}
