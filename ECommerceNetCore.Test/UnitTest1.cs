using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Validators;

namespace ECommerceNetCore.Test
{
    public class UnitTest1
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