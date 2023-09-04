using System;
using System.Collections.Generic;

namespace ECommerce.Domain.Entities;

public partial class DefCarrier : AggregateRoot
{

    public string CompanyName { get; set; } = null!;

    public string CompanyAddress { get; set; } = null!;

    public string? CompanyPhone { get; set; }

    public bool IsContracted { get; set; }

    public decimal Price { get; set; }

    public decimal? ContractedPrice { get; set; }
}
