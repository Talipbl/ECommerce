using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Helpers;
using ECommerceNetCore.Application.Validators;

namespace ECommerceNetCore.Test
{
    public class ProductTest
    {
        ProductMasterModelValidator validator = new ProductMasterModelValidator();
        [Fact]
        public void Test1()
        {
            byte[] passwordHash, passwordSalt;

            HashigHelper.CreatePasswordHash("admin1234", out passwordHash, out passwordSalt);
            var hash = "0x" + BitConverter.ToString(passwordHash).Replace("-", "");
            var salt = "0x" + BitConverter.ToString(passwordSalt).Replace("-", "");
        }
    }
}