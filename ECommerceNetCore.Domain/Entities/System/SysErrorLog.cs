using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class SysErrorLog : AggregateRoot
{

    public string? MethodName { get; set; }

    public string ErrorMessage { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
