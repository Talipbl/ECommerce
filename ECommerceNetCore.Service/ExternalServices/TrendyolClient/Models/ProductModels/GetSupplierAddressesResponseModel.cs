using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.ProductModels
{
    public class GetSupplierAddressesResponseModel
    {
        public List<SupplierAddressModel> SupplierAddresses { get; set; }
        public DefaultShipmentAddressModel DefaultShipmentAddress { get; set; }
        public DefaultInvoiceAddressModel DefaultInvoiceAddress { get; set; }
        public DefaultReturningAddressModel DefaultReturningAddress { get; set; }


        public class DefaultInvoiceAddressModel
        {
            public int Id { get; set; }
            public string AddressType { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public int CityCode { get; set; }
            public string District { get; set; }
            public int DistrictId { get; set; }
            public string PostCode { get; set; }
            public string Address { get; set; }
            public bool ReturningAddress { get; set; }
            public string FullAddress { get; set; }
            public bool ShipmentAddress { get; set; }
            public bool InvoiceAddress { get; set; }
            public bool Default { get; set; }
        }

        public class DefaultReturningAddressModel
        {
            public bool Present { get; set; }
        }

        public class DefaultShipmentAddressModel
        {
            public int Id { get; set; }
            public string AddressType { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public int CityCode { get; set; }
            public string District { get; set; }
            public int DistrictId { get; set; }
            public string PostCode { get; set; }
            public string Address { get; set; }
            public bool ReturningAddress { get; set; }
            public string FullAddress { get; set; }
            public bool ShipmentAddress { get; set; }
            public bool InvoiceAddress { get; set; }
            public bool Default { get; set; }
        }

        public class SupplierAddressModel
        {
            public int Id { get; set; }
            public string AddressType { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public int CityCode { get; set; }
            public string District { get; set; }
            public int DistrictId { get; set; }
            public string PostCode { get; set; }
            public string Address { get; set; }
            public bool ReturningAddress { get; set; }
            public string FullAddress { get; set; }
            public bool ShipmentAddress { get; set; }
            public bool InvoiceAddress { get; set; }
            public bool Default { get; set; }
        }
    }
}
