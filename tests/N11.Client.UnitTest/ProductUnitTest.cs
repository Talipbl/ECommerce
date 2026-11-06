using N11.Client;

namespace N11.Client.UnitTest
{
    /// <summary>
    /// Canlı N11 API'sine giden testler. CI'da çalışmaz (TestCategory=Live).
    /// Çalıştırmak için N11_APP_KEY ve N11_APP_SECRET ortam değişkenlerini tanımlayın.
    /// </summary>
    [TestClass]
    [TestCategory("Live")]
    public class ProductUnitTest
    {
        private N11ProductClient _client = null!;

        [TestInitialize]
        public void Initialize()
        {
            var appKey = Environment.GetEnvironmentVariable("N11_APP_KEY");
            var appSecret = Environment.GetEnvironmentVariable("N11_APP_SECRET");

            if (string.IsNullOrWhiteSpace(appKey) || string.IsNullOrWhiteSpace(appSecret))
                Assert.Inconclusive("N11_APP_KEY / N11_APP_SECRET tanımlı değil; canlı test atlandı.");

            _client = new N11ProductClient(appKey, appSecret);
        }

        [TestMethod]
        public void Get_Product_By_Id()
        {
            var result = _client.GetProductByIdAsync(651305567).Result;
        }

        [TestMethod]
        public void Get_Product_By_Code()
        {
            var result = _client.GetProductBySellerCodeAsync("TEST-4567").Result;
        }

        [TestMethod]
        public void Get_Products()
        {
            var result = _client.GetProductListAsync().Result;
        }

        [TestMethod]
        public void Get_Product_Counts()
        {
            var result = _client.GetProductAllStatusCountsAsync().Result;
        }
    }
}