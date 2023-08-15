using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class TrackingNumberModel
    {
        public string TrackingNumber { get; set; }
        public TrackingNumberModel(string trackingNumber)
        {
            TrackingNumber = trackingNumber;
        }
    }
}
