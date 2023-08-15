using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{

    public class ProcessAlternativeDeliveryRequest
    {
        public bool IsPhoneNumber { get; set; }
        public string TrackingInfo { get; set; }
        public ParamsModel Params { get; set; }
        public int BoxQuantity { get; set; }
        public double Deci { get; set; }


        public class ParamsModel
        {
            public string DigitalCode { get; set; }
        }
    }
}
