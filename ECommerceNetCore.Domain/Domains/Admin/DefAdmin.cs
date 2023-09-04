using ECommerce.Core.Domain;

namespace ECommerce.Admin;

public partial class DefAdmin : AggregateRoot<int>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public DateTime RegisterDate { get; set; }

    public DateTime? LastLoginDate { get; set; }

    public string MailAdress { get; set; } = null!;

    public string? OtpsetupCode { get; set; }

    public bool? IsEnable2Fa { get; set; }

    public bool? IsActive { get; set; }

    public int SecurityLevel { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public byte[]? PasswordHash { get; set; }
}
