using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient.Models.DeliveryModels
{
    public class CreateCommonLabelRequestModel
    {
        public string Format { get; set; }
        public int BoxQuantity { get; set; }
        public double VolumetricHeight { get; set; }
    }
    

    public class GetCommonLabelResponseModel
    {
        public List<Datum> Data { get; set; }
        public class Datum
        {
            public string Label { get; set; }
            public string Format { get; set; }
        }
    }
}
