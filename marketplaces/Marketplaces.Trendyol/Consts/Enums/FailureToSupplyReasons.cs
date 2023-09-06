using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplaces.Trendyol
{
    public enum FailureToSupplyReason
    {
        StockDepleted = 500,
        DefectiveProduct = 501,
        IncorrectPrice = 502,
        IntegrationError = 504,
        BulkPurchase = 505,
        ForceMajeure = 506
    }
}
