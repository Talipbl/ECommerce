using Newtonsoft.Json;
using static Trendyol.Client.DeleteProductRequestModel;

namespace Trendyol.Client
{
    public class TrendyolClient
    {
        readonly TrendyolProductClient _productClient;
        public TrendyolClient(ApiAuthentication authentication)
        {
            _productClient = new TrendyolProductClient(authentication);
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
        public async Task<RootResponseModel<GetProductsResponseModel>> GetProductsAsync(ProductQueryParametersModel parameters)
        {
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
        public async Task<BrandListModel> GetBrandsAsync()
        {
            var response = await _productClient.GetBrandsAsync();
            if (response.IsSuccess && response.OkResponse.Brands.Count > 0)
                return response.OkResponse;
            else
                return null;
        }

        /// <summary>
        /// CreateProductsAsync servisine yapılacak isteklerde gönderilecek brandId bilgisi bu servis kullanılarak alınacaktır. <paramref name="name"/> parametresi ile arama değeri girilir.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<List<BrandModel>> GetBrandsAsync(string name)
        {
            var response = await _productClient.GetBrandsByNameAsync(name);
            if (response.IsSuccess && response.OkResponse.Count > 0)
                return response.OkResponse;
            else
                return null;
        }

        /// <summary>
        /// CreateProductsAsync servisine yapılacak isteklerde gönderilecek categoryId bilgisi bu servis kullanılarak alınacaktır.
        /// </summary>
        /// <returns></returns>
        public async Task<CategoryListModel> GetCategoriesAsync()
        {
            var response = await _productClient.GetCategoriesAsync();
            if (response.IsSuccess && response.OkResponse.Categories.Count > 0)
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
        public async Task<RootResponseModel<ServiceResponseModel>> CreateProductsAsync(List<ProductModel> products)
        {
            RootResponseModel<ServiceResponseModel> response = new RootResponseModel<ServiceResponseModel>();
            ProductRequestModel model = new ProductRequestModel(products);

            var productResult = await _productClient.CreateProductsAsync(model);

            response.IsSuccess = productResult.IsSuccess;
            if (response.IsSuccess)
            {
                response.OkResponse.BatchRequestId = productResult.OkResponse.BatchRequestId;
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
        public async Task<RootResponseModel<ServiceResponseModel>> UpdatePriceAndInventoryAsync(List<PriceAndInventoryModel> priceAndInventories)
        {
            RootResponseModel<ServiceResponseModel> response = new();
            PriceAndInventoryUpdateRequest requestModel = new(priceAndInventories);
            var result = await _productClient.UpdatePriceAndInventoryAsync(requestModel);
            return result;
        }

        public async Task<RootResponseModel<ServiceResponseModel>> DeleteProductAsync(List<DeleteProduct> deleteProducts)
        {
            RootResponseModel<ServiceResponseModel> response = new();
            DeleteProductRequestModel requestModel = new(deleteProducts);
            var result = await _productClient.DeleteProductsAsync(requestModel);
            return result;
        }

        #endregion
    }
}
