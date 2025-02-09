using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Trendyol
{
    public class GetOrdersResponseDTO
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalPages { get; set; }
        public int TotalElements { get; set; }
        public List<ContentDTO> Content { get; set; }

        public class ContentDTO
        {
            public AddressDTO ShipmentAddress { get; set; }
            public string OrderNumber { get; set; }
            public double GrossAmount { get; set; }
            public double TotalDiscount { get; set; }
            public double TotalTyDiscount { get; set; }
            public object TaxNumber { get; set; }
            public AddressDTO InvoiceAddress { get; set; }
            public string CustomerFirstName { get; set; }
            public string CustomerEmail { get; set; }
            public int CustomerId { get; set; }
            public string CustomerLastName { get; set; }
            public long Id { get; set; }
            public long CargoTrackingNumber { get; set; }
            public string CargoTrackingLink { get; set; }
            public string CargoSenderNumber { get; set; }
            public string CargoProviderName { get; set; }
            public List<LineDTO> Lines { get; set; }
            public DateTime OrderDate { get; set; }
            public string TcIdentityNumber { get; set; }
            public string CurrencyCode { get; set; }
            public List<PackageHistoryDTO> PackageHistories { get; set; }
            public string ShipmentPackageStatus { get; set; }
            public string Status { get; set; }
            public string DeliveryType { get; set; }
            public int TimeSlotId { get; set; }
            public string ScheduledDeliveryStoreId { get; set; }
            public DateTime EstimatedDeliveryStartDate { get; set; }
            public DateTime EstimatedDeliveryEndDate { get; set; }
            public double TotalPrice { get; set; }
            public string DeliveryAddressType { get; set; }
            public DateTime AgreedDeliveryDate { get; set; }
            public bool AgreedDeliveryDateExtendible { get; set; }
            public DateTime ExtendedAgreedDeliveryDate { get; set; }
            public DateTime AgreedDeliveryExtensionStartDate { get; set; }
            public DateTime AgreedDeliveryExtensionEndDate { get; set; }
            public object InvoiceLink { get; set; }
            public bool FastDelivery { get; set; }
            public string FastDeliveryType { get; set; }
            public DateTime OriginShipmentDate { get; set; }
            public DateTime LastModifiedDate { get; set; }
            public bool Commercial { get; set; }
            public bool DeliveredByService { get; set; }
            public bool Micro { get; set; }
        }

        public class DiscountDetailDTO
        {
            public double LineItemPrice { get; set; }
            public double LineItemDiscount { get; set; }
            public double LineItemTyDiscount { get; set; }
        }

        public class AddressDTO
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Company { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public int CityCode { get; set; }
            public string District { get; set; }
            public int DistrictId { get; set; }
            public string PostalCode { get; set; }
            public string CountryCode { get; set; }
            public int NeighborhoodId { get; set; }
            public string Neighborhood { get; set; }
            public object Phone { get; set; }
            public string FullName { get; set; }
            public string FullAddress { get; set; }
            public string TaxOffice { get; set; }
            public string TaxNumber { get; set; }

            internal void AddInvoiceAddress(string id, string firstName, string lastName, string company, string address1, string address2, string city, int cityCode, string district, int districtId, string postalCode, string countryCode, int neighborhoodId, string neighborhood, object phone, string fullName, string fullAddress, string taxOffice, string taxNumber)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
                Company = company;
                Address1 = address1;
                Address2 = address2;
                City = city;
                CityCode = cityCode;
                District = district;
                DistrictId = districtId;
                PostalCode = postalCode;
                CountryCode = countryCode;
                NeighborhoodId = neighborhoodId;
                Neighborhood = neighborhood;
                Phone = phone;
                FullName = fullName;
                FullAddress = fullAddress;
                TaxOffice = taxOffice;
                TaxNumber = taxNumber;
            }

            internal void AddShipmentAddress(string id, string firstName, string lastName, string company, string address1, string address2, string city, string district, int districtId, string postalCode, string countryCode, int neighborhoodId, string neighborhood, object phone, string fullName, string fullAddress)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
                Company = company;
                Address1 = address1;
                Address2 = address2;
                City = city;
                District = district;
                DistrictId = districtId;
                PostalCode = postalCode;
                CountryCode = countryCode;
                NeighborhoodId = neighborhoodId;
                Neighborhood = neighborhood;
                Phone = phone;
                FullName = fullName;
                FullAddress = fullAddress;
            }
        }

        public class LineDTO
        {
            public int Quantity { get; set; }
            public int SalesCampaignId { get; set; }
            public string ProductSize { get; set; }
            public string MerchantSku { get; set; }
            public string ProductName { get; set; }
            public int ProductCode { get; set; }
            public int MerchantId { get; set; }
            public double Amount { get; set; }
            public double Discount { get; set; }
            public double TyDiscount { get; set; }
            public List<DiscountDetailDTO> DiscountDetails { get; set; }
            public List<string> FastDeliveryOptions { get; set; }
            public string CurrencyCode { get; set; }
            public string ProductColor { get; set; }
            public string Id { get; set; }
            public string Sku { get; set; }
            public float VatBaseAmount { get; set; }
            public string Barcode { get; set; }
            public string OrderLineItemStatusName { get; set; }
            public double Price { get; set; }
        }

        public class PackageHistoryDTO
        {
            public DateTime CreatedDate { get; set; }
            public string Status { get; set; }
        }
    }
}
