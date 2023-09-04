using ECommerce.Core.Domain;
using System;
using System.Collections.Generic;

namespace ECommerce.Systems;

public partial class SysErrorLog : AggregateRoot<int>
{

    public string? MethodName { get; set; }

    public string ErrorMessage { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
