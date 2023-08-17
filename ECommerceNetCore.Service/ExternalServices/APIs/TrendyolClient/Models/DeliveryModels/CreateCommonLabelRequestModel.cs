using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class CreateCommonLabelRequestModel
    {
        public string Format { get; set; }
        public int BoxQuantity { get; set; }
        public double VolumetricHeight { get; set; }
    }
}
