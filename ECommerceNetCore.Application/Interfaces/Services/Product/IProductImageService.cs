using ECommerce.Core.Application;

namespace ECommerce.Product;

public interface IProductImageService
{
    IDataResult<GnlProductImage> GetProductImage(string filename);
    IDataResult<GnlProductImage> AddProductImage(GnlProductImage image);
    IResult UpdateProductImage(GnlProductImage image);
    IResult DeleteProductImage(GnlProductImage image);
}
