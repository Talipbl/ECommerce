using AutoMapper;
using Trendyol.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Trendyol
{
    public class TrendyolCrawlerMappingProfile : Profile
    {
        public TrendyolCrawlerMappingProfile()
        {
            CreateMap<CrawlerProductDetailModel.ResultModel, TrendyolCrawlerProductDetailDTO>();
            CreateMap<CrawlerProductDetailModel.AllVariant, TrendyolCrawlerProductDetailDTO.AllVariant>();
            CreateMap<CrawlerProductDetailModel.Attribute, TrendyolCrawlerProductDetailDTO.Attribute>();
            CreateMap<CrawlerProductDetailModel.Key, TrendyolCrawlerProductDetailDTO.Key>();
            CreateMap<CrawlerProductDetailModel.Gender, TrendyolCrawlerProductDetailDTO.GenderModel>();
            CreateMap<CrawlerProductDetailModel.Brand, TrendyolCrawlerProductDetailDTO.BrandModel>();
            CreateMap<CrawlerProductDetailModel.BuyMorePayLessPromotion, TrendyolCrawlerProductDetailDTO.BuyMorePayLessPromotion>();
            CreateMap<CrawlerProductDetailModel.Campaign, TrendyolCrawlerProductDetailDTO.CampaignModel>();
            CreateMap<CrawlerProductDetailModel.Category, TrendyolCrawlerProductDetailDTO.CategoryModel>();
            CreateMap<CrawlerProductDetailModel.CategoryTopRankings, TrendyolCrawlerProductDetailDTO.CategoryTopRankingsModel>();
            CreateMap<CrawlerProductDetailModel.ContentDescription, TrendyolCrawlerProductDetailDTO.ContentDescription>();
            CreateMap<CrawlerProductDetailModel.CrossPromotionAward, TrendyolCrawlerProductDetailDTO.CrossPromotionAwardModel>();
            CreateMap<CrawlerProductDetailModel.CustomValue, TrendyolCrawlerProductDetailDTO.CustomValue>();
            CreateMap<CrawlerProductDetailModel.CutOffCountDown, TrendyolCrawlerProductDetailDTO.CutOffCountDown>();
            CreateMap<CrawlerProductDetailModel.DeliveryInformation, TrendyolCrawlerProductDetailDTO.DeliveryInformationModel>();
            CreateMap<CrawlerProductDetailModel.Description, TrendyolCrawlerProductDetailDTO.DescriptionModel>();
            CreateMap<CrawlerProductDetailModel.DiscountedPrice, TrendyolCrawlerProductDetailDTO.DiscountedPrice>();
            CreateMap<CrawlerProductDetailModel.FastDeliveryOption, TrendyolCrawlerProductDetailDTO.FastDeliveryOption>();
            CreateMap<CrawlerProductDetailModel.FilterableLabel, TrendyolCrawlerProductDetailDTO.FilterableLabel>();
            CreateMap<CrawlerProductDetailModel.MetaBrand, TrendyolCrawlerProductDetailDTO.MetaBrandModel>();
            CreateMap<CrawlerProductDetailModel.Merchant, TrendyolCrawlerProductDetailDTO.MerchantModel>();
            CreateMap<CrawlerProductDetailModel.OriginalCategory, TrendyolCrawlerProductDetailDTO.OriginalCategoryModel>();
            CreateMap<CrawlerProductDetailModel.OriginalPrice, TrendyolCrawlerProductDetailDTO.OriginalPrice>();
            CreateMap<CrawlerProductDetailModel.Price, TrendyolCrawlerProductDetailDTO.PriceModel>();
            CreateMap<CrawlerProductDetailModel.ProductStamp, TrendyolCrawlerProductDetailDTO.ProductStamp>();
            CreateMap<CrawlerProductDetailModel.Promotion, TrendyolCrawlerProductDetailDTO.Promotion>();
            CreateMap<CrawlerProductDetailModel.RatingScore, TrendyolCrawlerProductDetailDTO.RatingScoreModel>();
            CreateMap<CrawlerProductDetailModel.SellingPrice, TrendyolCrawlerProductDetailDTO.SellingPrice>();
            CreateMap<CrawlerProductDetailModel.Stamp, TrendyolCrawlerProductDetailDTO.Stamp>();
            CreateMap<CrawlerProductDetailModel.UnitInfo, TrendyolCrawlerProductDetailDTO.UnitInfo>();
            CreateMap<CrawlerProductDetailModel.Value, TrendyolCrawlerProductDetailDTO.Value>();
            CreateMap<CrawlerProductDetailModel.Variant, TrendyolCrawlerProductDetailDTO.Variant>();
            CreateMap<CrawlerProductDetailModel.WalletRebate, TrendyolCrawlerProductDetailDTO.WalletRebateModel>();
        }
    }
}
