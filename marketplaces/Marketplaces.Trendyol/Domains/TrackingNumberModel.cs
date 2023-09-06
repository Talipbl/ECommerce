using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplaces.Trendyol
{
    public class TrackingNumberModel
    {
        [JsonProperty("trackingNumber")]
        public string TrackingNumber { get; set; }
        public TrackingNumberModel(string trackingNumber)
        {
            TrackingNumber = trackingNumber;
        }
    }
}
