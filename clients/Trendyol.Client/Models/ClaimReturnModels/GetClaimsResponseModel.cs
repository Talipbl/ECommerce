using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Client
{
    public class GetClaimsResponseModel
    {
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public List<ContentModel> Content { get; set; }
        public List<Item> Items { get; set; }
        public class ContentModel
        {
            public string Id { get; set; }
            public string OrderNumber { get; set; }
            public long OrderDate { get; set; }
            public string CustomerFirstName { get; set; }
            public string CustomerLastName { get; set; }
            public long ClaimDate { get; set; }
            public string CargoTrackingNumber { get; set; }
            public string CargoTrackingLink { get; set; }
            public string CargoSenderNumber { get; set; }
            public string CargoProviderName { get; set; }
            public int OrderShipmentPackageId { get; set; }
            public ReplacementOutboundpackageinfoModel ReplacementOutboundpackageinfo { get; set; }
            public RejectedpackageinfoModel Rejectedpackageinfo { get; set; }
            public class RejectedpackageinfoModel
            {
                public string CargoTrackingNumber { get; set; }
                public string CargoProviderName { get; set; }
                public string CargoTrackingLink { get; set; }
                public int Packageid { get; set; }
                public List<string> Items { get; set; }
            }
            public class ReplacementOutboundpackageinfoModel
            {
                public string CargoTrackingNumber { get; set; }
                public string CargoProviderName { get; set; }
                public string CargoSenderNumber { get; set; }
                public string CargoTrackingLink { get; set; }
                public int Packageid { get; set; }
                public List<string> Items { get; set; }
            }
        }
        public class Item
        {
            public OrderLineModel OrderLine { get; set; }
            public List<ClaimItem> ClaimItems { get; set; }
            public class ClaimItem
            {
                public string Id { get; set; }
                public int OrderLineItemId { get; set; }
                public CustomerClaimItemReasonModel CustomerClaimItemReason { get; set; }
                public TrendyolClaimItemReasonModel TrendyolClaimItemReason { get; set; }
                public ClaimItemStatusModel ClaimItemStatus { get; set; }
                public string Note { get; set; }
                public string CustomerNote { get; set; }
                public bool Resolved { get; set; }
                public class ClaimItemStatusModel
                {
                    public string Name { get; set; }
                }
                public class CustomerClaimItemReasonModel
                {
                    public string Id { get; set; }
                    public string Name { get; set; }
                    public int ExternalReasonId { get; set; }
                    public string Code { get; set; }
                }
                public class TrendyolClaimItemReasonModel
                {
                    public string Id { get; set; }
                    public string Name { get; set; }
                    public int ExternalReasonId { get; set; }
                    public string Code { get; set; }
                }
            }
            public class OrderLineModel
            {
                public int Id { get; set; }
                public string ProductName { get; set; }
                public string Barcode { get; set; }
                public string MerchantSku { get; set; }
                public string ProductColor { get; set; }
                public string ProductSize { get; set; }
                public double Price { get; set; }
                public int VatBaseAmount { get; set; }
                public int SalesCampaignId { get; set; }
                public string ProductCategory { get; set; }
            }

        }

    }
}
