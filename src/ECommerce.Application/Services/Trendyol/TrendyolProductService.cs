using AutoMapper;
using ECommerce.Core.Application;
using ECommerce.Domain.Common.Constants;
using Trendyol.Client;
using static Trendyol.Client.DeleteProductRequestModel;

namespace ECommerce.Trendyol
{
    public class TrendyolProductService(IMapper mapper) : ITrendyolProductService
    {
        TrendyolClient _trendyolClient = new(ApiAuthentication.CreateAuthentication("atBqHAZm2Eg1ZttXGpMZ", "LSEzaIx17XkuFiYyXyRu", "836049"));

        private readonly IMapper _mapper = mapper;

        public async Task<IDataResult<TrendyolErrorResultDto>> CreateProductAsync(TrendyolProductDto product)
        {
            try
            {
                List<ProductModel> products = _mapper.Map<List<ProductModel>>(new List<TrendyolProductDto>() { product });
                var result = await _trendyolClient.CreateProductsAsync(products);
                if (result.IsSuccess)
                    return new DataResult<TrendyolErrorResultDto>(result.IsSuccess, result.OkResponse.BatchRequestId);

                var errorReturn = _mapper.Map<TrendyolErrorResultDto>(result.ErrorValueReturn);
                return new DataResult<TrendyolErrorResultDto>(errorReturn, result.IsSuccess);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<TrendyolErrorResultDto>> CreateProductsAsync(List<TrendyolProductDto> products)
        {
            try
            {
                List<ProductModel> tyProducts = _mapper.Map<List<ProductModel>>(products);
                var result = await _trendyolClient.CreateProductsAsync(tyProducts);
                if (result.IsSuccess)
                    return new DataResult<TrendyolErrorResultDto>(result.IsSuccess ,result.OkResponse.BatchRequestId);

                var errorReturn = _mapper.Map<TrendyolErrorResultDto>(result.ErrorValueReturn);
                return new DataResult<TrendyolErrorResultDto>(errorReturn, result.IsSuccess);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<TrendyolErrorResultDto>> DeleteProductAsync(List<string> productBarcodes)
        {
            List<DeleteProduct> model = productBarcodes.Select(x => new DeleteProduct() { Barcode = x }).ToList();
            var result = await _trendyolClient.DeleteProductAsync(model);

            if (result.IsSuccess)
                return new DataResult<TrendyolErrorResultDto>(result.IsSuccess, result.OkResponse.BatchRequestId);

            var errorReturn = _mapper.Map<TrendyolErrorResultDto>(result.ErrorValueReturn);
            return new DataResult<TrendyolErrorResultDto>(errorReturn, result.IsSuccess);
        }
        [CacheAspect(Duration = 300)]
        public async Task<IDataResult<List<BrandModel>>> GetBrandsAsync()
        {
            var result = await _trendyolClient.GetBrandsAsync();
            return new DataResult<List<BrandModel>>(result.Brands, true);
        }
        [CacheAspect(Duration = 500)]
        public async Task<IDataResult<List<BrandModel>>> GetBrandsAsync(string search, int size = 100)
        {
            var result = await _trendyolClient.GetBrandsAsync(search);
            if (result != null && result.Count > 0)
            {
                result = result.Where(s => s.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).Take(size).ToList();
                return new DataResult<List<BrandModel>>(result, true);
            }
            return new DataResult<List<BrandModel>>(false, "Brands not found!");
        }
        [CacheAspect(Duration = 300)]
        public async Task<IDataResult<List<CategoryModel>>> GetCategoriesAsync(string search, int size = 100)
        {
            //TO-DO: Kategori filtrelemesi yapılacak!
            var result = await _trendyolClient.GetCategoriesAsync();
            if (result != null && result.Categories.Count > 0)
            {
                return new DataResult<List<CategoryModel>>(result.Categories, true);
            }
            return new DataResult<List<CategoryModel>>(false, "Categories not found!");
        }

        public async Task<IDataResult<GetProductsResponseModel>> GetProductsAsync(ProductQueryParametersDto parameters)
        {
            ProductQueryParametersModel model = new()
            {
                Barcode = parameters.Barcode,
                StockCode = parameters.StockCode,
                ProductMainId = parameters.ProductMainId,
                Approved = parameters.Approved,
                Archived = parameters.Archived,
                Blacklisted = parameters.Blacklisted,
                OnSale = parameters.OnSale,
                Rejected = parameters.Rejected,
                StartDate = parameters.StartDate != default ? ((DateTimeOffset)parameters.StartDate).ToUnixTimeSeconds() : null,
                EndDate = parameters.EndDate != default ? ((DateTimeOffset)parameters.EndDate).ToUnixTimeSeconds() : null,
                BrandIds = parameters.BrandIds,
                DateQueryType = parameters.DateQueryType,
                Page = parameters.Page,
                Size = parameters.Size
            };

            var result = await _trendyolClient.GetProductsAsync(model);

            return new DataResult<GetProductsResponseModel>(result.OkResponse, result.IsSuccess);
        }

        public async Task<IDataResult<TrendyolErrorResultDto>> UpdatePriceAndInventoryAsync(List<TrendyolPriceAndInventoryDto> priceAndInventories)
        {
            List<PriceAndInventoryModel> model = _mapper.Map<List<PriceAndInventoryModel>>(priceAndInventories);
            var result = await _trendyolClient.UpdatePriceAndInventoryAsync(model);

            if (result.IsSuccess)
                return new DataResult<TrendyolErrorResultDto>(result.IsSuccess, result.OkResponse.BatchRequestId);

            var errorReturn = _mapper.Map<TrendyolErrorResultDto>(result.ErrorValueReturn);
            return new DataResult<TrendyolErrorResultDto>(errorReturn, result.IsSuccess);
        }
    }
}
