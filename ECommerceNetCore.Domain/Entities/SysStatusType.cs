using System;
using System.Collections.Generic;

namespace ECommerceNetCore.Domain.Entities;

public partial class SysStatusType :BaseEntity
{

    public string StatusName { get; set; } = null!;

    public virtual ICollection<GnlOrderPayment> GnlOrderPayments { get; } = new List<GnlOrderPayment>();

    public virtual ICollection<GnlOrder> GnlOrders { get; } = new List<GnlOrder>();

    public virtual ICollection<GnlProductOption> GnlProductOptions { get; } = new List<GnlProductOption>();

    public virtual ICollection<GnlProductPrice> GnlProductPrices { get; } = new List<GnlProductPrice>();

    public virtual ICollection<GnlProductXml> GnlProductXmls { get; } = new List<GnlProductXml>();

    public virtual ICollection<GnlProduct> GnlProducts { get; } = new List<GnlProduct>();

    public virtual ICollection<GnlUser> GnlUsers { get; } = new List<GnlUser>();

    public virtual ICollection<GnlXmlScheduler> GnlXmlSchedulers { get; } = new List<GnlXmlScheduler>();
}
