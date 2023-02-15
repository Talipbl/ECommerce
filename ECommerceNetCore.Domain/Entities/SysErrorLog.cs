using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class SysErrorLog : BaseEntity
{

    public string? MethodName { get; set; }

    public string ErrorMessage { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
