using ECommerce.Core.Application;

namespace ECommerce.Product;

public interface IProductService
{
    IDataResult<GnlProduct> AddProduct(GnlProduct product);
    IDataResult<ProductMasterModelDto> AddProduct(ProductMasterModelDto product);
    IResult UpdateProduct(GnlProduct product);
    IResult DeleteProduct(int id);
    IListResult<GnlProduct> GetAllProducts();
    IListResult<ProductsModelDto> GetProducts(int categoryId = (int)CategoryTypes.All, int brandId = (int)StatusTypes.All, int manufacturerId = (int)StatusTypes.All, int xmlId = (int)StatusTypes.All, int statusId = (int)StatusTypes.Active, int start = 0, int take = 25);
    IListResult<GnlProduct> GetProduct(string upc = "", string ean = "", string jan = "", string isbn = "", string mpn = "", int statusId = (int)StatusTypes.Active);
    IDataResult<ProductMasterModelDto> GetProductMaster(int productId);
    IDataResult<GnlProduct> GetProduct(int productId);
    int GetProductsCount();
}
