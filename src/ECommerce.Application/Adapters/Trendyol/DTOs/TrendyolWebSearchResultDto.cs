using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Trendyol
{
    public class TrendyolWebSearchResultDTO
    {
        public string SlpName { get; set; }
        public List<Product>? Products { get; set; }
        public int TotalCount { get; set; }
        public string RoughTotalCount { get; set; }
        public string SearchStrategy { get; set; }
        public string Title { get; set; }
        public string UxLayout { get; set; }
        public string QueryTerm { get; set; }
        public int PageIndex { get; set; }
        public List<Widget> Widgets { get; set; }

        public class Product
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public List<string>? Images { get; set; }
            public string? ImageAlt { get; set; }
            public BrandModel? Brand { get; set; }
            public int Tax { get; set; }
            public RatingScoreModel? RatingScore { get; set; }
            public bool ShowSexualContent { get; set; }
            public int ProductGroupId { get; set; }
            public bool HasReviewPhoto { get; set; }
            public string? CardType { get; set; }
            public List<Section>? Sections { get; set; }
            public List<Variant>? Variants { get; set; }
            public string? CategoryHierarchy { get; set; }
            public int CategoryId { get; set; }
            public string? CategoryName { get; set; }
            public string? Url { get; set; }
            public int MerchantId { get; set; }
            public int CampaignId { get; set; }
            public PriceModel? Price { get; set; }
            public List<Promotion>? Promotions { get; set; }
            public int RushDeliveryDuration { get; set; }
            public bool FreeCargo { get; set; }
            public string? CampaignName { get; set; }
            public string? ListingId { get; set; }
            public string? WinnerVariant { get; set; }
            public int ItemNumber { get; set; }
            public string? DiscountedPriceInfo { get; set; }
            public bool HasVideoContent { get; set; }
            public bool HasCrossPromotion { get; set; }
            public bool HasCollectableCoupon { get; set; }
            public bool SameDayShipping { get; set; }
            public int LowestPriceDuration { get; set; }
            public PriceLabelModel? PriceLabel { get; set; }
            public bool IsLegalRequirementConfirmed { get; set; }
            public List<Badge>? Badges { get; set; }
            public List<Stamp>? Stamps { get; set; }
            public int? CollectableCouponDiscount { get; set; }

            public class Promotion
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string ShortName { get; set; }
                public DateTime PromotionEndDate { get; set; }
            }
            public class RatingScoreModel
            {
                public double AverageRating { get; set; }
                public int TotalCount { get; set; }
            }
            public class Section
            {
                public string Id { get; set; }
            }
            public class Stamp
            {
                public string ImageUrl { get; set; }
                public string Type { get; set; }
                public string Position { get; set; }
                public double AspectRatio { get; set; }
                public int Priority { get; set; }
                public string TagType { get; set; }
            }
            public class Variant
            {
                public string AttributeValue { get; set; }
                public string AttributeName { get; set; }
                public PriceModel Price { get; set; }
                public string ListingId { get; set; }
                public int CampaignId { get; set; }
                public int MerchantId { get; set; }
                public string DiscountedPriceInfo { get; set; }
                public bool HasCollectableCoupon { get; set; }
                public bool SameDayShipping { get; set; }
                public int LowestPriceDuration { get; set; }
                public PriceLabelModel PriceLabel { get; set; }
            }

            public class Badge
            {
                public string Title { get; set; }
                public string Type { get; set; }
                public bool? Priority { get; set; }
            }
            public class PriceModel
            {
                public double DiscountedPrice { get; set; }
                public int BuyingPrice { get; set; }
                public double OriginalPrice { get; set; }
                public double SellingPrice { get; set; }
            }
            public class PriceLabelModel
            {
                public string Name { get; set; }
                public string Value { get; set; }
                public int Type { get; set; }
            }
            public class BrandModel
            {
                public int Id { get; set; }
                public string? Name { get; set; }
            }
        }

        public class Widget
        {
            public ConfigurationModel Configuration { get; set; }
            public string Type { get; set; }
            public string DisplayType { get; set; }
            public string FeedingSource { get; set; }
            public string FeedingSourceDataKey { get; set; }
            public int DisplayOrder { get; set; }
            public int WidgetOrder { get; set; }
            public string Title { get; set; }
            public string EventKey { get; set; }

            public class ConfigurationModel
            {
                public int StorefrontId { get; set; }
                public string Culture { get; set; }
                public string WidgetGwUrl { get; set; }
                public string AccountGwUrl { get; set; }
                public string RecoGwUrl { get; set; }
                public bool PriceBoxV2Enabled { get; set; }
                public bool SearchStoreAdsDisabled { get; set; }
                public string PublicSfxWidgetGwUrl { get; set; }
            }
        }
    }
}
