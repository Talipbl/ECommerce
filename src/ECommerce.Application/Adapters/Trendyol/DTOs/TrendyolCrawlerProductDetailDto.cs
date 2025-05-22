using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Trendyol
{
    public class TrendyolCrawlerProductDetailDto
    {
        public List<Attribute> Attributes { get; set; }
        public List<object> SelectedVasAttributes { get; set; }
        public List<object> AlternativeVariants { get; set; }
        public List<Variant> Variants { get; set; }
        public List<object> OtherMerchants { get; set; }
        public CampaignModel Campaign { get; set; }
        public CategoryModel Category { get; set; }
        public BrandModel Brand { get; set; }
        public string Color { get; set; }
        public MetaBrandModel MetaBrand { get; set; }
        public bool ShowVariants { get; set; }
        public bool ShowSexualContent { get; set; }
        public List<object> BrandCategoryBanners { get; set; }
        public List<AllVariant> AllVariants { get; set; }
        public List<object> OtherMerchantVariants { get; set; }
        public string Token { get; set; }
        public bool IsThereAnyCorporateInvoiceInOtherMerchants { get; set; }
        public object AdvertProduct { get; set; }
        public CategoryTopRankingsModel CategoryTopRankings { get; set; }
        public bool IsVasEnabled { get; set; }
        public OriginalCategoryModel OriginalCategory { get; set; }
        public List<object> Landings { get; set; }
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string NameWithProductCode { get; set; }
        public List<ContentDescription> ContentDescriptions { get; set; }
        public List<object> Faq { get; set; }
        public List<DescriptionModel> Description { get; set; }
        public int ProductGroupId { get; set; }
        public int Tax { get; set; }
        public string BusinessUnit { get; set; }
        public int BusinessUnitId { get; set; }
        public int MaxInstallment { get; set; }
        public GenderModel Gender { get; set; }
        public string Url { get; set; }
        public List<string> Images { get; set; }
        public bool IsSellable { get; set; }
        public bool IsBasketDiscount { get; set; }
        public bool HasStock { get; set; }
        public PriceModel Price { get; set; }
        public bool IsFreeCargo { get; set; }
        public bool IsLongTermDelivery { get; set; }
        public List<Promotion> Promotions { get; set; }
        public MerchantModel Merchant { get; set; }
        public DeliveryInformationModel DeliveryInformation { get; set; }
        public int CargoRemainingDays { get; set; }
        public bool IsMarketplaces { get; set; }
        public List<ProductStamp> ProductStamps { get; set; }
        public bool HasHtmlContent { get; set; }
        public int FavoriteCount { get; set; }
        public string UxLayout { get; set; }
        public bool IsDigitalGood { get; set; }
        public bool IsRunningOut { get; set; }
        public bool ScheduledDelivery { get; set; }
        public RatingScoreModel RatingScore { get; set; }
        public bool ShowStarredAttributes { get; set; }
        public string ReviewsUrl { get; set; }
        public string QuestionsUrl { get; set; }
        public bool SellerQuestionEnabled { get; set; }
        public string SizeChartUrl { get; set; }
        public bool SizeExpectationAvailable { get; set; }
        public CrossPromotionAwardModel CrossPromotionAward { get; set; }
        public bool RushDeliveryMerchantListingExist { get; set; }
        public bool IsRushDelivery { get; set; }
        public bool LowerPriceMerchantListingExist { get; set; }
        public bool ShowValidFlashSales { get; set; }
        public bool ShowExpiredFlashSales { get; set; }
        public WalletRebateModel WalletRebate { get; set; }
        public bool IsArtWork { get; set; }
        public List<BuyMorePayLessPromotion> BuyMorePayLessPromotions { get; set; }
        public List<FilterableLabel> FilterableLabels { get; set; }
        public List<CustomValue> CustomValues { get; set; }

        public class AllVariant
        {
            public int ItemNumber { get; set; }
            public string Value { get; set; }
            public bool InStock { get; set; }
            public string Currency { get; set; }
            public string Barcode { get; set; }
            public double Price { get; set; }
        }

        public class Attribute
        {
            public Key Key { get; set; }
            public Value Value { get; set; }
            public bool Starred { get; set; }
            public string Description { get; set; }
            public List<object> MediaUrls { get; set; }
        }

        public class BrandModel
        {
            public bool IsVirtual { get; set; }
            public string BeautifiedName { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public string Path { get; set; }
        }

        public class BuyMorePayLessPromotion
        {
            public int Id { get; set; }
            public int SelectionOverQuantity { get; set; }
            public double DiscountedPrice { get; set; }
            public double TotalNonDiscountedPrice { get; set; }
            public double? TotalDiscountedPrice { get; set; }
            public int? SavingRate { get; set; }
        }

        public class CampaignModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public bool IsMultipleSupplied { get; set; }
            public int StockTypeId { get; set; }
            public string Url { get; set; }
            public bool ShowTimer { get; set; }
        }

        public class CategoryModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Hierarchy { get; set; }
            public bool Refundable { get; set; }
            public string BeautifiedName { get; set; }
            public bool IsVASEnabled { get; set; }
        }

        public class CategoryTopRankingsModel
        {
            public string Name { get; set; }
            public int Order { get; set; }
            public string Url { get; set; }
            public string Text { get; set; }
        }

        public class ContentDescription
        {
            public string Description { get; set; }
            public bool Bold { get; set; }
        }

        public class CrossPromotionAwardModel
        {
            public string AwardType { get; set; }
            public string AwardValue { get; set; }
            public int ContentId { get; set; }
            public int MerchantId { get; set; }
        }

        public class CustomValue
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        public class CutOffCountDown
        {
            public int Years { get; set; }
            public int Months { get; set; }
            public int Days { get; set; }
            public int Hours { get; set; }
            public int Minutes { get; set; }
            public int Seconds { get; set; }
        }

        public class DeliveryInformationModel
        {
            public bool IsRushDelivery { get; set; }
            public string DeliveryDate { get; set; }
            public List<FastDeliveryOption> FastDeliveryOptions { get; set; }
        }

        public class DescriptionModel
        {
            public string Text { get; set; }
            public int Priority { get; set; }
        }

        public class DiscountedPrice
        {
            public string Text { get; set; }
            public double Value { get; set; }
        }

        public class FastDeliveryOption
        {
            public string Type { get; set; }
            public string DailyCutoffHour { get; set; }
            public string DeliveryTimeZone { get; set; }
            public CutOffCountDown CutOffCountDown { get; set; }
        }

        public class FilterableLabel
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string DisplayName { get; set; }
            public bool VisibleAgg { get; set; }
        }

        public class GenderModel
        {
        }

        public class HeadersModel
        {
            public string Tysidecarcachable { get; set; }
        }

        public class Key
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }

        public class MerchantModel
        {
            public bool IsSearchableMerchant { get; set; }
            public List<object> Stickers { get; set; }
            public List<object> MerchantBadges { get; set; }
            public List<object> MerchantMarkers { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public string OfficialName { get; set; }
            public string CityName { get; set; }
            public string TaxNumber { get; set; }
            public double SellerScore { get; set; }
            public string SellerScoreColor { get; set; }
            public string DeliveryProviderName { get; set; }
            public bool CorporateInvoiceApplicable { get; set; }
            public bool LocationBasedSales { get; set; }
            public int BulkSalesLimit { get; set; }
            public string SellerLink { get; set; }
        }

        public class MetaBrandModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string BeautifiedName { get; set; }
            public bool IsVirtual { get; set; }
            public string Path { get; set; }
        }

        public class OriginalCategoryModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Hierarchy { get; set; }
            public bool Refundable { get; set; }
            public string BeautifiedName { get; set; }
            public bool IsVASEnabled { get; set; }
        }

        public class OriginalPrice
        {
            public string Text { get; set; }
            public double Value { get; set; }
        }

        public class PriceModel
        {
            public int ProfitMargin { get; set; }
            public DiscountedPrice DiscountedPrice { get; set; }
            public SellingPrice SellingPrice { get; set; }
            public OriginalPrice OriginalPrice { get; set; }
            public string Currency { get; set; }
        }

        public class ProductStamp
        {
            public string Type { get; set; }
            public string ImageUrl { get; set; }
            public string Position { get; set; }
            public double AspectRatio { get; set; }
            public int Priority { get; set; }
        }

        public class Promotion
        {
            public string PromotionRemainingTime { get; set; }
            public int Type { get; set; }
            public string Text { get; set; }
            public int Id { get; set; }
            public string PromotionDiscountType { get; set; }
            public string Link { get; set; }
        }

        public class RatingScoreModel
        {
            public double AverageRating { get; set; }
            public int TotalRatingCount { get; set; }
            public int TotalCommentCount { get; set; }
        }

        public class SellingPrice
        {
            public string Text { get; set; }
            public double Value { get; set; }
        }

        public class Stamp
        {
            public int Type { get; set; }
            public string Text { get; set; }
        }

        public class UnitInfo
        {
            public bool UnitPrice { get; set; }
            public bool UnitPriceText { get; set; }
        }

        public class Value
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }

        public class Variant
        {
            public int AttributeId { get; set; }
            public string AttributeName { get; set; }
            public string AttributeType { get; set; }
            public string AttributeValue { get; set; }
            public List<Stamp> Stamps { get; set; }
            public PriceModel Price { get; set; }
            public string FulfilmentType { get; set; }
            public string AttributeBeautifiedValue { get; set; }
            public bool IsWinner { get; set; }
            public string ListingId { get; set; }
            public object Stock { get; set; }
            public bool Sellable { get; set; }
            public bool AvailableForClaim { get; set; }
            public string Barcode { get; set; }
            public int ItemNumber { get; set; }
            public string DiscountedPriceInfo { get; set; }
            public bool HasCollectable { get; set; }
            public UnitInfo UnitInfo { get; set; }
            public bool RushDeliveryMerchantListingExist { get; set; }
            public bool LowerPriceMerchantListingExist { get; set; }
            public List<FastDeliveryOption> FastDeliveryOptions { get; set; }
            public List<string> GroupTagIds { get; set; }
        }

        public class WalletRebateModel
        {
            public int MinPrice { get; set; }
            public int MaxPrice { get; set; }
            public double RebateRatio { get; set; }
        }
    }
}
