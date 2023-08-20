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

            ApiAuthenticationModel authorization = new ApiAuthenticationModel()
            {
                SellerId = "2738",
                ApiKey = "7vw1GSi8UV5MF5y2wh9Q",
                ApiSecretKey = "ziAoE6pBo1DS6yYaYYdW",
                Authorization = $"Basic {auth}"
            };

            //_productClient = new TrendyolProductClient(new ApiAuthenticationModel().CreateAuthentication(AuthenticationType.Basic, "7vw1GSi8UV5MF5y2wh9Q", "ziAoE6pBo1DS6yYaYYdW", "", "2738"));
            _productClient = new TrendyolProductClient(authorization);
        }

        #region Ürün Entegrasyonu

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
        /// CreateProductsAsync servisine yapılacak isteklerde gönderilecek sipariş ve sevkiyat kargo firma bilgileri ve bu bilgilere ait ID değerleri bu servis kullanılarak alınacaktır.
        /// </summary>
        /// <returns></returns>
        public async Task<RootResponseModel<GetSupplierAddressesResponseModel>> GetSupplierAddressAsync()
        {
            return await _productClient.GetSupplierAddressesAsync();
        }

        /// <summary>
        /// CreateProductsAsync servisine yapılacak isteklerde gönderilecek brandId bilgisi bu servis kullanılarak alınacaktır.
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
        /// CreateProductsAsync servisine yapılacak isteklerde gönderilecek categoryId bilgisi bu servis kullanılarak alınacaktır.
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
        /// CreateProductsAsync servisine yapılacak isteklerde gönderilecek attributes bilgileri ve bu bilgilere ait detaylar bu servis kullanılarak alınacaktır.
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

        /// <summary>
        /// CreateProductsAsync, UpdatePriceAndInventoryAsync methodları servise yapılan istekler kuyruğa atarak işlendiği için, servise yapılan her başarlı istek sonucunda bir adet batchRequestId bilgisi dönülmektedir. Bu method yardımıyla batchRequestId ile alınan işlemlerin sonucunun kontrolü yapılabilir. Servis dönüşündeki "status" alanı kontrol edilerek toplu işlemin tamamlanıp tamamlanmadığı kontrol edilebilir. Eğer toplu işlem sonucunda bir ya da birden fazla item için hata oluşmuş ise <b>FailureReasons</b> alanı kontrol edilerek sebebi bulunabilir.
        /// </summary>
        /// <param name="batchRequestId"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<BatchRequestResultModel>> GetBatchRequestAsync(string batchRequestId)
        {
            return await _productClient.GetBatchRequestAsync(batchRequestId);
        }

        /// <summary>
        /// Ürünleriniz Trendyol sistemine yüklenirken bu metod kullanılmaktadır. Tekli ve çoklu ürün gönderimini desteklemektedir.
        /// </summary>
        /// <remarks>
        /// + Bu method ile ürün aktarımı sağlanmadan önce Trendyol Marka Liste ve Kategori/Kategori Özellik bilgileri servisleri üzerinden ilgili detaylar alınmalıdır.<br />
        /// + Her bir istek içerisinde gönderilebilecek maksimum item sayısı 1.000'dir.<br />
        /// + <b>FastDeliveryType</b> alanında tanımlama yapabilmek için <b>DeliveryDuration</b> alanını 1 olarak girilmesi gerekmektedir.
        /// </remarks>
        /// <param name="products"></param>
        /// <returns>İşlem başarılı ise geriye BatchRequestResultModel ile işlem sonucu döner. Başarısız ise ErrorResultModel döner.</returns>
        public async Task<RootResponseModel<ServiceResponseModel, BatchRequestResultModel>> CreateProductsAsync(List<ProductModel> products)
        {
            RootResponseModel<ServiceResponseModel, BatchRequestResultModel> response = new RootResponseModel<ServiceResponseModel, BatchRequestResultModel>();
            ProductRequestModel model = new ProductRequestModel(products);

            var productResult = await _productClient.CreateProductsAsync(model);

            response.IsSuccess = productResult.IsSuccess;
            if (response.IsSuccess)
            {
                var batchResult = await _productClient.GetBatchRequestAsync(productResult.OkResponse.BatchRequestId);
                response.AdditionalData = batchResult.OkResponse;
                response.OkResponse = productResult.OkResponse;

                return response;
            }

            response.ErrorValueReturn = JsonConvert.DeserializeObject<ErrorResultModel>((string)productResult.ErrorValueReturn);
            return response;
        }

        /// <summary>
        /// Bu method ile Trendyol mağazanızda CreateProductsAsync servisiyle oluşturduğunuz ürünleri güncelleyebilirsiniz.
        /// </summary>
        /// <remarks>
        /// + Bu servis üzerinden sadece ürün bilgileri güncellenmektedir. Stok ve fiyat değerlerini güncellemek için updatePriceAndInventory servisini kullanmanız gerekmektedir.<br />
        /// + Yeni kategori ve kategori özellik değerleri eklenebileceği sebebiyle ürün güncellemelerinizden önce kullandığınız kategori ve kategori özellik değerlerinin güncel olup olmadığını getCategoryTree ve getCategoryAttributes servislerinden kontrol etmenizi öneririz.<br />
        /// + Güncelleme isteğinden sonra "İçerik kontrol bekleniyor." statüsüne geçen ürünleriniz satışa açık durumda olabilir.Sipariş almak istemediğiniz durumlarda stok ve fiyat bilginizi sıfırlamanız gerekmektedir.<br />
        /// + Her bir istek içerisinde gönderilebilecek maksimum item sayısı 1.000'dir.
        /// </remarks>
        /// <param name="products"></param>
        /// <returns>İşlem başarılı ise geriye BatchRequestResultModel ile işlem sonucu döner. Başarısız ise ErrorResultModel döner.</returns>
        public async Task<RootResponseModel<ServiceResponseModel, BatchRequestResultModel>> UpdateProductsAsync(List<ProductModel> products)
        {
            RootResponseModel<ServiceResponseModel, BatchRequestResultModel> response = new RootResponseModel<ServiceResponseModel, BatchRequestResultModel>();
            ProductRequestModel model = new ProductRequestModel(products);

            var productResult = await _productClient.UpdateProductsAsync(model);

            response.IsSuccess = productResult.IsSuccess;
            if (response.IsSuccess)
            {
                var batchResult = await _productClient.GetBatchRequestAsync(productResult.OkResponse.BatchRequestId);
                response.AdditionalData = batchResult.OkResponse;
                response.OkResponse = productResult.OkResponse;

                return response;
            }

            response.ErrorValueReturn = JsonConvert.DeserializeObject<ErrorResultModel>((string)productResult.ErrorValueReturn);
            return response;
        }

        /// <summary>
        /// Trendyol'a aktarılan ve onaylanan ürünlerin fiyat ve stok bilgileri eş zamana yakın güncellenir. Stok ve fiyat bligilerini istek içerisinde ayrı ayrı gönderebilirsiniz.
        /// </summary>
        /// <param name="priceAndInventories"></param>
        /// <returns></returns>
        public async Task<RootResponseModel<ServiceResponseModel, BatchRequestResultModel>> UpdatePriceAndInventoryAsync(List<PriceAndInventoryModel> priceAndInventories)
        {
            RootResponseModel<ServiceResponseModel, BatchRequestResultModel> response = new RootResponseModel<ServiceResponseModel, BatchRequestResultModel>();
            PriceAndInventoryUpdateRequest requestModel = new PriceAndInventoryUpdateRequest(priceAndInventories);
            var priceResult = await _productClient.UpdatePriceAndInventoryAsync(requestModel);

            response.IsSuccess = priceResult.IsSuccess;
            if (response.IsSuccess)
            {
                var batchResult = await _productClient.GetBatchRequestAsync(priceResult.OkResponse.BatchRequestId);
                response.AdditionalData = batchResult.OkResponse;
                response.OkResponse = priceResult.OkResponse;

                return response;
            }

            return response;
        }

        #endregion
    }
}
