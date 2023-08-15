using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class AgreedDeliveryDateExtendibleRequest
    {
        public int ExtendedDayCount { get; set; }
        public AgreedDeliveryDateExtendibleRequest(int extendedDayCount)
        {
            ExtendedDayCount = extendedDayCount;
        }
    }
}
