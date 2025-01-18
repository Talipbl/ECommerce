using N11.Client;

namespace N11.Client.UnitTest
{
    [TestClass]
    public class ProductUnitTest
    {
        private readonly N11ProductClient _client;
        public ProductUnitTest()
        {
            _client = new N11ProductClient("b4be11bf-9517-4aa2-b4ed-0abeec287516", "KHQWHrHbMEIymEA8");
        }

        [TestMethod]
        public void Get_Product_By_Id()
        {
            var result = _client.GetProductById(651305567).Result;
        }

        [TestMethod]
        public void Get_Product_By_Code()
        {
            var result = _client.GetProductBySellerCode("TEST-4567").Result;
        }

        [TestMethod]
        public void Get_Products()
        {
            var result = _client.GetProductList().Result;
        }

        [TestMethod]
        public void Get_Product_Counts()
        {
            var result = _client.GetProductAllStatusCounts().Result;
        }
    }
}