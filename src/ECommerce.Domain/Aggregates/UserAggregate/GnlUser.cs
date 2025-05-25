using ECommerce.Domain;
using ECommerce.Order;
using ECommerce.Systems;
using System;
using System.Collections.Generic;

namespace ECommerce.User;

public partial class GnlUser : AggregateRoot<int>
{

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Identity { get; set; }

    public string? TaxNumber { get; set; }

    public string MailAddress { get; set; } = null!;

    public string? MobilePhoneNumber { get; set; }

    public string? FixedPhoneNumber { get; set; }

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int StatusId { get; set; }

    public bool IsCorporate { get; set; }

    public virtual ICollection<GnlOrder> GnlOrders { get; } = new List<GnlOrder>();

    public virtual ICollection<GnlUserCoupon> GnlUserCoupons { get; } = new List<GnlUserCoupon>();

    public virtual ICollection<GnlUserMailQueue> GnlUserMailQueues { get; } = new List<GnlUserMailQueue>();

    public virtual SysStatusType Status { get; set; } = null!;
}
