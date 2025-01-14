using AutoMapper;
using ECommerce.Core.Application;
using ECommerce.Domain.Common.Constants;
using Trendyol.Client;
using Newtonsoft.Json;
using System.Linq;

namespace ECommerce.Trendyol
{
    public class TrendyolService(IMapper mapper) : ITrendyolService
    {
        TrendyolClient _trendyolClient = new(ApiAuthentication.CreateAuthentication("atBqHAZm2Eg1ZttXGpMZ", "LSEzaIx17XkuFiYyXyRu", "836049"));
        TrendyolDiscoveryClient _discoveryClient = new();

        IMapper _mapper = mapper;

        public async Task<IDataResult<TrendyolWebSearchResultDto>> SearchCrawlerProducts(string url, int page = 1)
        {
            try
            {
                string search = url.Split("https://www.trendyol.com/").Last();
                var result = await _discoveryClient.GetWebSearchResult(search, page);
                if (!result.IsSuccess)
                    return new DataResult<TrendyolWebSearchResultDto>(false, TrendyolConst.ServiceConnectionError);

                var response = result.OkResponse.Result;
                var productModel = _mapper.Map<TrendyolWebSearchResultDto>(response);

                return new SuccessDataResult<TrendyolWebSearchResultDto>(productModel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IDataResult<TrendyolCrawlerProductDetailDto>> GetCrawlerProductDetail(int productId)
        {
            try
            {
                var result = await _discoveryClient.GetProductDetail(productId);
                if (!result.IsSuccess)
                    return new DataResult<TrendyolCrawlerProductDetailDto>(false, TrendyolConst.ServiceConnectionError);

                var response = result.OkResponse.Result;
                var detailModel = _mapper.Map<TrendyolCrawlerProductDetailDto>(response);

                return new SuccessDataResult<TrendyolCrawlerProductDetailDto>(detailModel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IDataResult<TrendyolBatchRequestResultDto, TrendyolErrorResultDto>> CreateProducts(List<TrendyolProductDto> products)
        {
            try
            {
                List<ProductModel> tyProducts = _mapper.Map<List<ProductModel>>(products);
                var result = await _trendyolClient.CreateProductsAsync(tyProducts);
                var batchRequest = _mapper.Map<TrendyolBatchRequestResultDto>(result.AdditionalData);
                if (result.IsSuccess)
                    return new DataResult<TrendyolBatchRequestResultDto, TrendyolErrorResultDto>(batchRequest, result.IsSuccess);

                var errorReturn = _mapper.Map<TrendyolErrorResultDto>(result.ErrorValueReturn);
                return new DataResult<TrendyolBatchRequestResultDto, TrendyolErrorResultDto>(batchRequest, errorReturn, result.IsSuccess);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<GetProductsResponseModel>> GetProducts(int page = 0, int size = 0, QueryBooleanOption isApproved = QueryBooleanOption.All, QueryBooleanOption isArchived = QueryBooleanOption.All, QueryBooleanOption isOnSale = QueryBooleanOption.All, QueryBooleanOption isRejected = QueryBooleanOption.All, QueryBooleanOption isBlacklisted = QueryBooleanOption.All, DateType dateType = DateType.CREATED_DATE, DateTime startDate = default, DateTime endDate = default, string barcode = "", string stockCode = "", string productMainId = "", string[]? brandIds = null)
        {
            var result = await _trendyolClient.GetProductsAsync(page, size, isApproved, isArchived, isOnSale, isRejected, isBlacklisted, dateType, startDate, endDate, barcode, stockCode, productMainId, brandIds);

            return new DataResult<GetProductsResponseModel>(result.OkResponse, result.IsSuccess);
        }

        public async Task<IDataResult<TrendyolBatchRequestResultDto, TrendyolErrorResultDto>> CreateCopyProduct(int[] ids)
        {
            List<TrendyolProductDto> products = new List<TrendyolProductDto>();

            foreach (var id in ids)
            {
                var detail = await GetCrawlerProductDetail(id);
                if (!detail.Success) continue;

                var detailData = detail.Data;

                var categoryAttr = await _trendyolClient.GetCategoryAttributes(detailData.OriginalCategory.Id);

                List<TrendyolRequestAttributeDto> listAttr = new List<TrendyolRequestAttributeDto>();
                foreach (var attr in detailData.Attributes)
                {
                    if (attr.Key.Id is not 348)
                    {
                        var attributes = categoryAttr.OkResponse.CategoryAttributes;
                        if (!attributes.Select(x => x.Attribute.Id).Contains(attr.Key.Id))
                            continue;

                        listAttr.Add(new TrendyolRequestAttributeDto()
                        {
                            AttributeId = attr.Key.Id,
                            AttributeValueId = attr.Value.Id
                        });
                    }
                }

                if(detailData.Color is not null)
                {
                    listAttr.Add(new TrendyolRequestAttributeDto()
                    {
                        AttributeId = 47,//Renk parametresi
                        CustomAttributeValue = detailData.Color
                    });
                }

                List<TrendyolImageDto> listImg = new List<TrendyolImageDto>();
                detailData.Images.ForEach(img =>
                {
                    listImg.Add(new TrendyolImageDto() { Url = TrendyolConst.ImagePrefix + img }); //TO-DO: Buradaki sabit marketplace içersine veya bu projede uygun bir yere taşınacak.
                });

                string description = detailData.Name;
                detailData.Description.ForEach(desc =>
                {
                    if (desc.Priority is 0)
                        description += desc.Text;
                });

                int vatRate = 0;
                var customValues = detailData.CustomValues;

                var vatValues = customValues.Where(x => x.Key.Equals("vatRate")).FirstOrDefault();
                vatRate = vatValues is not null ? Convert.ToInt32(vatValues.Value) is 0 ? 20: Convert.ToInt32(vatValues.Value) : 20; //Varsayılan KDV %20

                double dimensional = 0.0;
                var dimensionalValue = customValues.Where(x => x.Key.Equals("dimensionalWeight")).FirstOrDefault();
                dimensional = dimensionalValue is not null ? Convert.ToDouble(dimensionalValue.Value) : 0.0;

                TrendyolProductDto product = new TrendyolProductDto()
                {
                    Barcode = detailData.Variants.First().Barcode,
                    Title = detailData.Name,
                    ProductMainId = detailData.Id,
                    BrandId = detailData.MetaBrand.Id,
                    CategoryId = detailData.OriginalCategory.Id,
                    StockCode = detailData.ProductCode,
                    Description = description,
                    CurrencyType = detailData.Price.Currency,
                    ListPrice = detailData.Price.OriginalPrice.Value,
                    SalePrice = detailData.Price.SellingPrice.Value,
                    VatRate = vatRate,
                    DimensionalWeight = dimensional,
                    CargoCompanyId = 10,//(int)CargoCompany.MNGMP,
                    ShipmentAddressId = 6754332,// TODO: Satıcı adres bilgileri servisten çekilecek.
                    ReturningAddressId = 6754333,
                    Attributes = listAttr,
                    Images = listImg
                };

                product = ConfigureCrawlerProduct(product);
                products.Add(product);
            }

            return await CreateProducts(products);
        }

        private TrendyolProductDto ConfigureCrawlerProduct(TrendyolProductDto product)
        {
            product.Barcode += "TBT1";
            product.Quantity = 2;
            product.ListPrice *= 1.00 + 60.00 / 100.00;
            product.SalePrice *= 1.00 + 60.00 / 100.00;
            product.DeliveryDuration = 2;
            product.DeliveryOption = new TrendyolDeliveryOptionDto() { DeliveryDuration = 2 };

            return product;
        }
    }
}
