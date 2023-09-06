using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplaces.Trendyol
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
