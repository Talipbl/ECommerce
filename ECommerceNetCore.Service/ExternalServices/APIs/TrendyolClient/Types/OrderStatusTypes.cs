using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public enum OrderStatus
    {
        Awaiting,
        Created,
        Picking,
        Invoiced,
        Shipped,
        Cancelled,
        Delivered,
        UnDelivered,
        Returned,
        Repack,
        UnSupplied
    }
}
