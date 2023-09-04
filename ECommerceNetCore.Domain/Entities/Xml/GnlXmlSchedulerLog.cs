using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class GnlXmlSchedulerLog : AggregateRoot
{

    public int SchedulereId { get; set; }

    public int XmlId { get; set; }

    public DateTime? WorkedTime { get; set; }

    public bool IsSuccess { get; set; }

    public virtual GnlXmlScheduler Scheduler { get; set; } = null!;

    public virtual GnlProductXml Xml { get; set; } = null!;
}
