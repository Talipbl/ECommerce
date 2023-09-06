using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplaces.Trendyol
{
    public class ChangeCargoProviderRequest
    {
        [JsonProperty("cargoProvider")]
        public string CargoProvider { get; set; }
        public ChangeCargoProviderRequest(string cargoProvider)
        {
            CargoProvider = cargoProvider;
        }
    }
}
