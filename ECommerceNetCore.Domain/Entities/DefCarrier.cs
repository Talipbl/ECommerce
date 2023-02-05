using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class DefCarrier : BaseEntity
{

    public string CompanyName { get; set; } = null!;

    public string CompanyAddress { get; set; } = null!;

    public string? CompanyPhone { get; set; }

    public bool IsContracted { get; set; }

    public decimal Price { get; set; }

    public decimal? ContractedPrice { get; set; }
}
