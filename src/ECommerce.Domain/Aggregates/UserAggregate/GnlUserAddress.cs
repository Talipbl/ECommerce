using ECommerce.Domain;
using System;
using System.Collections.Generic;

namespace ECommerce.User;

public partial class GnlUserAddress : AggregateRoot<int>
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string MobilePhoneNumber { get; set; } = null!;

    public string? FixedPhoneNumber { get; set; }

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public bool IsCorporate { get; set; }

    public string? Identity { get; set; }

    public string? TaxNumber { get; set; }

    public int IsDefault { get; set; }
}
