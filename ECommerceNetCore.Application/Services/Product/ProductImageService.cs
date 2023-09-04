using ECommerce.Core.Application;

namespace ECommerce.Product;

public class ProductImageService : IProductImageService
{
    public IDataResult<GnlProductImage> GetProductImage(string filename)
    {
        return _imageRepo.GetImage(filename);
    }

    [LogAspect]
    public IDataResult<GnlProductImage> AddProductImage(GnlProductImage image)
    {
        var result = _imageRepo.Add(image);
        return new SuccessDataResult<GnlProductImage>(result);
    }

    public IResult DeleteProductImage(GnlProductImage image)
    {
        return new Result(_imageRepo.Delete(image));
    }

    public IResult UpdateProductImage(GnlProductImage image)
    {
        throw new NotImplementedException();
    }
}
