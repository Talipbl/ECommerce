using ECommerce.Core.Application;

namespace ECommerce.Product;

public class ProductImageService : IProductImageService
{
    IProductImageRepository ProductImageRepo { get; }

    public ProductImageService(IProductImageRepository productImageRepo)
    {
        ProductImageRepo = productImageRepo;
    }

    public IDataResult<GnlProductImage> GetProductImage(string filename)
    {
        var result = ProductImageRepo.GetImage(filename);
        return null;
    }

    [LogAspect]
    public IDataResult<GnlProductImage> AddProductImage(GnlProductImage image)
    {
        var result = ProductImageRepo.Add(image);
        return new SuccessDataResult<GnlProductImage>(result);
    }

    public IResult DeleteProductImage(GnlProductImage image)
    {
        return new Result(ProductImageRepo.Delete(image));
    }

    public IResult UpdateProductImage(GnlProductImage image)
    {
        throw new NotImplementedException();
    }
}
