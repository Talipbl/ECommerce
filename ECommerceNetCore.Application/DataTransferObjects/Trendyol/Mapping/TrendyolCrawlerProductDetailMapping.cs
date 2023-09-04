using AutoMapper;
using Marketplace.Trendyol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Trendyol
{
    public class TrendyolCrawlerProductDetailMapping : Profile
    {
        public TrendyolCrawlerProductDetailMapping()
        {
            CreateMap<CrawlerProductDetailModel.ResultModel, TrendyolCrawlerProductDetailDto>();
            CreateMap<CrawlerProductDetailModel.AllVariant, TrendyolCrawlerProductDetailDto.AllVariant>();
            CreateMap<CrawlerProductDetailModel.Attribute, TrendyolCrawlerProductDetailDto.Attribute>();
            CreateMap<CrawlerProductDetailModel.Key, TrendyolCrawlerProductDetailDto.Key>();
            CreateMap<CrawlerProductDetailModel.Gender, TrendyolCrawlerProductDetailDto.GenderModel>();
            CreateMap<CrawlerProductDetailModel.Brand, TrendyolCrawlerProductDetailDto.BrandModel>();
            CreateMap<CrawlerProductDetailModel.BuyMorePayLessPromotion, TrendyolCrawlerProductDetailDto.BuyMorePayLessPromotion>();
            CreateMap<CrawlerProductDetailModel.Campaign, TrendyolCrawlerProductDetailDto.CampaignModel>();
            CreateMap<CrawlerProductDetailModel.Category, TrendyolCrawlerProductDetailDto.CategoryModel>();
            CreateMap<CrawlerProductDetailModel.CategoryTopRankings, TrendyolCrawlerProductDetailDto.CategoryTopRankingsModel>();
            CreateMap<CrawlerProductDetailModel.ContentDescription, TrendyolCrawlerProductDetailDto.ContentDescription>();
            CreateMap<CrawlerProductDetailModel.CrossPromotionAward, TrendyolCrawlerProductDetailDto.CrossPromotionAwardModel>();
            CreateMap<CrawlerProductDetailModel.CustomValue, TrendyolCrawlerProductDetailDto.CustomValue>();
            CreateMap<CrawlerProductDetailModel.CutOffCountDown, TrendyolCrawlerProductDetailDto.CutOffCountDown>();
            CreateMap<CrawlerProductDetailModel.DeliveryInformation, TrendyolCrawlerProductDetailDto.DeliveryInformationModel>();
            CreateMap<CrawlerProductDetailModel.Description, TrendyolCrawlerProductDetailDto.DescriptionModel>();
            CreateMap<CrawlerProductDetailModel.DiscountedPrice, TrendyolCrawlerProductDetailDto.DiscountedPrice>();
            CreateMap<CrawlerProductDetailModel.FastDeliveryOption, TrendyolCrawlerProductDetailDto.FastDeliveryOption>();
            CreateMap<CrawlerProductDetailModel.FilterableLabel, TrendyolCrawlerProductDetailDto.FilterableLabel>();
            CreateMap<CrawlerProductDetailModel.MetaBrand, TrendyolCrawlerProductDetailDto.MetaBrandModel>();
            CreateMap<CrawlerProductDetailModel.Merchant, TrendyolCrawlerProductDetailDto.MerchantModel>();
            CreateMap<CrawlerProductDetailModel.OriginalCategory, TrendyolCrawlerProductDetailDto.OriginalCategoryModel>();
            CreateMap<CrawlerProductDetailModel.OriginalPrice, TrendyolCrawlerProductDetailDto.OriginalPrice>();
            CreateMap<CrawlerProductDetailModel.Price, TrendyolCrawlerProductDetailDto.PriceModel>();
            CreateMap<CrawlerProductDetailModel.ProductStamp, TrendyolCrawlerProductDetailDto.ProductStamp>();
            CreateMap<CrawlerProductDetailModel.Promotion, TrendyolCrawlerProductDetailDto.Promotion>();
            CreateMap<CrawlerProductDetailModel.RatingScore, TrendyolCrawlerProductDetailDto.RatingScoreModel>();
            CreateMap<CrawlerProductDetailModel.SellingPrice, TrendyolCrawlerProductDetailDto.SellingPrice>();
            CreateMap<CrawlerProductDetailModel.Stamp, TrendyolCrawlerProductDetailDto.Stamp>();
            CreateMap<CrawlerProductDetailModel.UnitInfo, TrendyolCrawlerProductDetailDto.UnitInfo>();
            CreateMap<CrawlerProductDetailModel.Value, TrendyolCrawlerProductDetailDto.Value>();
            CreateMap<CrawlerProductDetailModel.Variant, TrendyolCrawlerProductDetailDto.Variant>();
            CreateMap<CrawlerProductDetailModel.WalletRebate, TrendyolCrawlerProductDetailDto.WalletRebateModel>();
        }
    }
}
