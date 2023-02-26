using ECommerceNetCore.Application.Aspects;
using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Common;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IProductService
    {
        #region Product

        IDataResult<GnlProduct> AddProduct(GnlProduct product);
        IDataResult<ProductMasterModelDto> AddProduct(ProductMasterModelDto product);
        IResult UpdateProduct(GnlProduct product);
        IResult DeleteProduct(int id);
        IListResult<GnlProduct> GetAllProducts();
        IListResult<GnlProduct> GetProducts(int categoryId = (int)CategoryTypes.All, int brandId = (int)StatusTypes.All, int manufacturerId = (int)StatusTypes.All, int xmlId = (int)StatusTypes.All, int statusId = (int)StatusTypes.Active, bool onlyInStock = true, bool onlySale = false);
        IListResult<GnlProduct> GetProduct(string upc = "", string ean = "", string jan = "", string isbn = "", string mpn = "", int statusId = (int)StatusTypes.Active);
        IDataResult<GnlProduct> GetProduct(int productId);
        #endregion

        #region ProductImage

        IDataResult<GnlProductImage> AddProductImage(GnlProductImage image);
        IResult UpdateProductImage(GnlProductImage image);
        IResult DeleteProductImage(int id);
        #endregion

        #region Product Option

        IDataResult<GnlProductOption> AddProductOption(GnlProductOption option);
        IResult UpdateProductOption(GnlProductOption option);
        IResult DeleteProductOption(int id);
        IListResult<GnlProductOption> GetAllProductOption();
        IListResult<GnlProductOption> GetProductOptions(int productId, int statusId = (int)StatusTypes.Active);
        IListResult<GnlProductOption> GetProductOption(int optionId);
        #endregion

        #region Product Price

        IDataResult<GnlProductPrice> AddProductPrice(GnlProductPrice price);
        IResult UpdateProductPrice(GnlProductPrice price);
        IResult DeleteProductPrice(int id);
        IListResult<GnlProductPrice> GetAllProductPrice();
        IListResult<GnlProductPrice> GetProductPrices(int productId, int optionId = 0, bool onlySale = false, int statusId = (int)StatusTypes.Active);
        IListResult<GnlProductPrice> GetProductPrice(int priceId);
        #endregion

    }
}
