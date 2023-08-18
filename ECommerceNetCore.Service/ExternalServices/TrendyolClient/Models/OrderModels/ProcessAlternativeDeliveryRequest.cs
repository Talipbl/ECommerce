using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{

    public class ProcessAlternativeDeliveryRequest
    {
        [JsonProperty("isPhoneNumber")]
        public bool IsPhoneNumber { get; set; }

        [JsonProperty("trackingInfo")]
        public string TrackingInfo { get; set; }

        [JsonProperty("params")]
        public ParamsModel Params { get; set; }

        [JsonProperty("boxQuantity")]
        public int BoxQuantity { get; set; }

        [JsonProperty("deci")]
        public double Deci { get; set; }


        public class ParamsModel
        {
            [JsonProperty("digitalCode")]
            public string DigitalCode { get; set; }
        }
    }
}
