using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public enum FailureToSupplyReasonTypes
    {
        StockDepleted = 500,
        DefectiveProduct = 501,
        IncorrectPrice = 502,
        IntegrationError = 504,
        BulkPurchase = 505,
        ForceMajeure = 506
    }
}
