using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class TrendyolClient
    {
        // Test Ortamı
        // 7vw1GSi8UV5MF5y2wh9Q:ziAoE6pBo1DS6yYaYYdW
        // 2738

        // Canlı Ortamı
        // mhnqkT7WsnoMmpca49NY:yYxBaDjJw1QaRykToWHt
        // 836049

        TrendyolProductClient _productClient;
        public TrendyolClient()
        {
            string auth = Convert.ToBase64String(Encoding.ASCII.GetBytes("7vw1GSi8UV5MF5y2wh9Q:ziAoE6pBo1DS6yYaYYdW")); 

            ApiAuthorizationModel authorization = new ApiAuthorizationModel()
            {
                SupplierId = "2738",
                ApiKey = "7vw1GSi8UV5MF5y2wh9Q",
                ApiSecretKey = "ziAoE6pBo1DS6yYaYYdW",
                Authorization = $"Basic {auth}"
            };

            _productClient = new TrendyolProductClient(authorization);
        }

        #region Products

        /// <summary>
        /// Bu servis ile Trendyol mağazanızdaki ürünlerinizi listeleyebilirsiniz.
        /// </summary>
        /// <param name="page">İstenilen sayfanın numarası</param>
        /// <param name="size">Sayfada listelenecek ürün sayısı</param>
        /// <param name="isApproved">Ürün onaylı ya da onaysız kontrolü için kullanılır. <br /> <b>Evet/Hayır/Hepsi</b></param>
        /// <param name="isArchived">Arşivlenmiş ürünleri listelemek için  <br /> <b>Evet/Hayır/Hepsi</b></param>
        /// <param name="isOnSale">Satıştaki ürünleri listelemek için  <br /> <b>Evet/Hayır/Hepsi</b></param>
        /// <param name="isRejected">Reddedilen ürünleri listelemek için  <br /> <b>Evet/Hayır/Hepsi</b></param>
        /// <param name="isBlacklisted">Black list ürünleri listelemek için  <br /> <b>Evet/Hayır/Hepsi</b></param>
        /// <param name="dateType">Tarih filtresinin çalışacağı tarih CREATED_DATE ya da LAST_MODIFIED_DATE gönderilebilir</param>
        /// <param name="startDate">Belirli bir tarihten sonraki ürünleri getirir. </param>
        /// <param name="endDate">Belirli bir tarihten sonraki önceki getirir. </param>
        /// <param name="barcode">Tekil barkod sorgulamak için gönderilmelidir</param>
        /// <param name="stockCode">İlgili tedarikçinin stock code bilgisi gönderilmelidir</param>
        /// <param name="productMainId">İlgili tedarikçinin productMainId bilgisi gönderilmelidir</param>
        /// <param name="brandIds">Belirtilen brandId'ye sahip ürünleri listelemek için kullanılmalıdır. String array olarak gönderilmelidir</param>
        /// <returns><paramref name="GetProductsResponseModel"></paramref></returns>
        public async Task<RootResponseModel<GetProductsResponseModel>> GetProductsAsync(int page = 0, int size = 0,
            QueryBooleanOption isApproved = QueryBooleanOption.All,
            QueryBooleanOption isArchived = QueryBooleanOption.All,
            QueryBooleanOption isOnSale = QueryBooleanOption.All,
            QueryBooleanOption isRejected = QueryBooleanOption.All,
            QueryBooleanOption isBlacklisted = QueryBooleanOption.All,
            DateType dateType = DateType.CREATED_DATE,
            DateTime startDate = default, DateTime endDate = default,
            string barcode = "", string stockCode = "", string productMainId = "", string[]? brandIds = default)
        {
            ProductQueryParametersModel parameters = new ProductQueryParametersModel()
            {
                Approved = isApproved,
                Archived = isArchived,
                Barcode = barcode,
                StockCode = stockCode,
                Blacklisted = isBlacklisted,
                Rejected = isRejected,
                DateQueryType = dateType,
                ProductMainId = productMainId,
                OnSale = isOnSale,
                StartDate = startDate != default ? ((DateTimeOffset)startDate).ToUnixTimeSeconds() : null,
                EndDate = endDate != default ? ((DateTimeOffset)endDate).ToUnixTimeSeconds() : null,
                Page = page,
                Size = size,
                BrandIds = brandIds
            };

            return await _productClient.GetProductsAsync(parameters);
        }

        /// <summary>
        /// GetProductsAsync servisine yapılacak isteklerde gönderilecek sipariş ve sevkiyat kargo firma bilgileri ve bu bilgilere ait ID değerleri bu servis kullanılarak alınacaktır.
        /// </summary>
        /// <returns></returns>
        public async Task<RootResponseModel<GetSupplierAddressesResponseModel>> GetSupplierAddressAsync()
        {
            return await _productClient.GetSupplierAddressesAsync();
        }

        /// <summary>
        /// GetProductsAsync servisine yapılacak isteklerde gönderilecek brandId bilgisi bu servis kullanılarak alınacaktır.
        /// </summary>
        /// <returns></returns>
        public async Task<List<BrandModel>> GetBrandsAsync()
        {
            var response = await _productClient.GetBrandsAsync();
            if (response.IsSuccess && response.OkResponse.Count > 0)
                return response.OkResponse;
            else
                return null;
        }

        /// <summary>
        /// GetProductsAsync servisine yapılacak isteklerde gönderilecek categoryId bilgisi bu servis kullanılarak alınacaktır.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryModel>> GetCategoriesAsync()
        {
            var response = await _productClient.GetCategoriesAsync();
            if (response.IsSuccess && response.OkResponse.Count > 0)
                return response.OkResponse;
            else
                return null;
        }

        /// <summary>
        /// GetProductsAsync servisine yapılacak isteklerde gönderilecek attributes bilgileri ve bu bilgilere ait detaylar bu servis kullanılarak alınacaktır.
        /// </summary>
        /// <remarks>GetProductsAsync yapmak için en alt seviyedeki kategori ID bilgisi kullanılmalıdır. Seçtiğiniz kategorinin alt kategorileri var ise bu kategori bilgisi ile ürün aktarımı yapamazsınız.</remarks>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<AttributesModel>> GetCategoryAttributes(int categoryId)
        {
            var result = await _productClient.GetCategoryAttributesAsync(categoryId);
            if (!result.IsSuccess)
            {
                result.ErrorValueReturn = JsonConvert.DeserializeObject<ErrorResultModel>((string)result.ErrorValueReturn);
            }

            return result;
        }

        public async Task<RootResponseModel<ServiceResponseModel>> CreateProductsAsync(List<ProductModel> products)
        {
            ProductRequestModel model = new ProductRequestModel(products);

            var result = await _productClient.CreateProductsAsync(model);
            return result;
        }

        #endregion
    }
}
