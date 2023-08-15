using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class ChangeCargoProviderRequest
    {
        public string CargoProvider { get; set; }
        public ChangeCargoProviderRequest(string cargoProvider)
        {
            CargoProvider = cargoProvider;
        }
    }
}
