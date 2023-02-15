using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class DefAdmin : BaseEntity
{

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public DateTime RegisterDate { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public string Password { get; set; } = null!;

    public string MailAdress { get; set; } = null!;

    public string? OtpsetupCode { get; set; }

    public bool? IsEnable2Fa { get; set; }

    public bool? IsActive { get; set; }

    public int SecurityLevel { get; set; }
}
