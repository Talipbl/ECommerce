using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class AgreedDeliveryDateExtendibleRequest
    {
        [JsonProperty("extendedDayCount")]
        public int ExtendedDayCount { get; set; }
        public AgreedDeliveryDateExtendibleRequest(int extendedDayCount)
        {
            ExtendedDayCount = extendedDayCount;
        }
    }
}
