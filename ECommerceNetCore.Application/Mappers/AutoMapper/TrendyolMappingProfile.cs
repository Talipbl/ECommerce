using AutoMapper;
using ECommerceNetCore.Application.DataTransferObjects;
using Marketplace.Trendyol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECommerceNetCore.Application.DataTransferObjects.TrendyolErrorResultDto;

namespace ECommerceNetCore.Application.Mappers
{
    public class TrendyolMappingProfile : Profile
    {
        public TrendyolMappingProfile()
        {
            CreateMap<WebSearchResultModel.ResultModel, TrendyolWebSearchResultDto>();
            CreateMap<TrendyolWebSearchResultDto, WebSearchResultModel.ResultModel>();

            CreateMap<WebSearchResultModel.Widget, TrendyolWebSearchResultDto.Widget>();
            CreateMap<WebSearchResultModel.Widget.ConfigurationModel, TrendyolWebSearchResultDto.Widget.ConfigurationModel>();
            CreateMap<WebSearchResultModel.Product.BrandModel, TrendyolWebSearchResultDto.Product.BrandModel>();
            CreateMap<WebSearchResultModel.Product.RatingScoreModel, TrendyolWebSearchResultDto.Product.RatingScoreModel>();
            CreateMap<WebSearchResultModel.Product.Section, TrendyolWebSearchResultDto.Product.Section>();
            CreateMap<WebSearchResultModel.Product.Variant, TrendyolWebSearchResultDto.Product.Variant>();
            CreateMap<WebSearchResultModel.Product.PriceModel, TrendyolWebSearchResultDto.Product.PriceModel>();
            CreateMap<WebSearchResultModel.Product.PriceLabelModel, TrendyolWebSearchResultDto.Product.PriceLabelModel>();
            CreateMap<WebSearchResultModel.Product.Badge, TrendyolWebSearchResultDto.Product.Badge>();
            CreateMap<WebSearchResultModel.Product.Stamp, TrendyolWebSearchResultDto.Product.Stamp>();
            CreateMap<WebSearchResultModel.Product.Promotion, TrendyolWebSearchResultDto.Product.Promotion>();
            CreateMap<WebSearchResultModel.Product, TrendyolWebSearchResultDto.Product>();

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

            CreateMap<ProductModel, TrendyolProductDto>();
            CreateMap<TrendyolProductDto, ProductModel>();
            CreateMap<ProductModel.RequestAttribute, TrendyolRequestAttributeDto>();
            CreateMap<TrendyolRequestAttributeDto, ProductModel.RequestAttribute>();
            CreateMap<TrendyolImageDto, ImageModel>();
            CreateMap<ImageModel, TrendyolImageDto>();
            CreateMap<DeliveryOptionModel, TrendyolDeliveryOptionDto>();
            CreateMap<TrendyolDeliveryOptionDto, DeliveryOptionModel>();

            CreateMap<TrendyolBatchRequestResultDto, BatchRequestResultModel>();
            CreateMap<BatchRequestResultModel, TrendyolBatchRequestResultDto>();

            CreateMap<TrendyolErrorResultDto, ErrorResultModel>();
            CreateMap<ErrorResultModel, TrendyolErrorResultDto>();
            CreateMap<ErrorModelDto, ErrorResultModel.ErrorModel>();
            CreateMap<ErrorResultModel.ErrorModel, ErrorModelDto>();
        }
    }
}
