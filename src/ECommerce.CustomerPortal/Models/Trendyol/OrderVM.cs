using ECommerce.Trendyol;
using Trendyol.Client;

namespace Ecommerce.Trendyol
{
    public class OrderVM
    {
        public string OrderNumber { get; set; }
        public double GrossAmount { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalTyDiscount { get; set; }
        public object TaxNumber { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerEmail { get; set; }
        public int CustomerId { get; set; }
        public string CustomerLastName { get; set; }
        public long Id { get; set; }
        public long CargoTrackingNumber { get; set; }
        public string CargoTrackingLink { get; set; }
        public string CargoSenderNumber { get; set; }
        public string CargoProviderName { get; set; }
        public DateTime OrderDate { get; set; }
        public string TcIdentityNumber { get; set; }
        public string CurrencyCode { get; set; }
        public string ShipmentPackageStatus { get; set; }
        public string Status { get; set; }
        public string DeliveryType { get; set; }
        public int TimeSlotId { get; set; }
        public string ScheduledDeliveryStoreId { get; set; }
        public DateTime EstimatedDeliveryStartDate { get; set; }
        public DateTime EstimatedDeliveryEndDate { get; set; }
        public double TotalPrice { get; set; }
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

        internal static OrderVM GetOrderVM(GetOrdersResponseDTO.ContentDTO model)
        {
            return new OrderVM()
            {
                OrderNumber = model.OrderNumber,
                GrossAmount = model.GrossAmount,
                TotalDiscount = model.TotalDiscount,
                TotalTyDiscount = model.TotalTyDiscount,
                TaxNumber = model.TaxNumber,
                CustomerFirstName = model.CustomerFirstName,
                CustomerEmail = model.CustomerEmail,
                CustomerId = model.CustomerId,
                CustomerLastName = model.CustomerLastName,
                Id = model.Id,
                CargoTrackingNumber = model.CargoTrackingNumber,
                CargoTrackingLink = model.CargoTrackingLink,
                CargoSenderNumber = model.CargoSenderNumber,
                CargoProviderName = model.CargoProviderName,
                OrderDate = model.OrderDate,
                TcIdentityNumber = model.TcIdentityNumber,
                CurrencyCode = model.CurrencyCode,
                ShipmentPackageStatus = model.ShipmentPackageStatus,
                Status = model.Status,
                DeliveryType = model.DeliveryType,
                TimeSlotId = model.TimeSlotId,
                ScheduledDeliveryStoreId = model.ScheduledDeliveryStoreId,
                EstimatedDeliveryStartDate = model.EstimatedDeliveryStartDate,
                EstimatedDeliveryEndDate = model.EstimatedDeliveryEndDate,
                TotalPrice = model.TotalPrice,
                AgreedDeliveryDate = model.AgreedDeliveryDate,
                AgreedDeliveryDateExtendible = model.AgreedDeliveryDateExtendible,
                ExtendedAgreedDeliveryDate = model.ExtendedAgreedDeliveryDate,
                AgreedDeliveryExtensionStartDate = model.AgreedDeliveryExtensionStartDate,
                AgreedDeliveryExtensionEndDate = model.AgreedDeliveryExtensionEndDate,
                InvoiceLink = model.InvoiceLink,
                FastDelivery = model.FastDelivery,
                FastDeliveryType = model.FastDeliveryType,
                OriginShipmentDate = model.OriginShipmentDate,
                LastModifiedDate = model.LastModifiedDate,
                Commercial = model.Commercial,
                DeliveredByService = model.DeliveredByService,
                Micro = model.Micro,
            };
        }
    }
}
