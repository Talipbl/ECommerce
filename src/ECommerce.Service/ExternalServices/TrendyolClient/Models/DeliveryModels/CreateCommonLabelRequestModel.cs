using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.DeliveryModels
{
    public class CreateCommonLabelRequestModel
    {
        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("boxQuantity")]
        public int BoxQuantity { get; set; }

        [JsonProperty("volumetricHeight")]
        public double VolumetricHeight { get; set; }
    }
}
