using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class ProductRequestModel
    {
        public List<Product> Items { get; set; }

        public class Product
        {
            public string Barcode { get; set; }
            public string Title { get; set; }
            public string ProductMainId { get; set; }
            public int BrandId { get; set; }
            public int CategoryId { get; set; }
            public int Quantity { get; set; }
            public string StockCode { get; set; }
            public int DimensionalWeight { get; set; }
            public string Description { get; set; }
            public string CurrencyType { get; set; }
            public double ListPrice { get; set; }
            public double SalePrice { get; set; }
            public int VatRate { get; set; }
            public int CargoCompanyId { get; set; }
            public int ShipmentAddressId { get; set; }
            public int ReturningAddressId { get; set; }
            public int DeliveryDuration { get; set; }
            public DeliveryOptionModel DeliveryOption { get; set; }
            public List<Image> Images { get; set; }
            public List<Attribute> Attributes { get; set; }
        }

        public class Attribute
        {
            public int AttributeId { get; set; }
            public int AttributeValueId { get; set; }
            public string CustomAttributeValue { get; set; }
        }

        public class DeliveryOptionModel
        {
            public int DeliveryDuration { get; set; }
            public string FastDeliveryType { get; set; }
        }

        public class Image
        {
            public string Url { get; set; }
        }
    }
}
