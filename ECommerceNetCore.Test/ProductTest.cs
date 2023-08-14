using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Validators;
using ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient;

namespace ECommerceNetCore.Test
{
    public class ProductTest
    {
        ProductMasterModelValidator validator = new ProductMasterModelValidator();
        [Fact]
        public void Test1()
        {
            ProductMasterModelDto model = new ProductMasterModelDto();
            var result = validator.Validate(model);
        }
    }
}