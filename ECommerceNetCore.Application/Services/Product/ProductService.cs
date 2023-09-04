using ECommerce.Core.Application;

namespace ECommerce.Product;

[LogAspect]
public class ProductService : IProductService
{
    IProductRepository _productRepo;
    IProductImageRepository _imageRepo;
    IProductPriceRepository _priceRepo;
    IProductOptionRepository _optionRepo;
    IProductCategoryRepository _categoryRepo;

    public ProductService(IProductRepository productRepo, IProductCategoryRepository proCategoryRepo, IProductOptionRepository productOptionRepo, IProductImageRepository imageRepo, IProductPriceRepository priceRepo)
    {
        _productRepo = productRepo;
        _categoryRepo = proCategoryRepo;
        _optionRepo = productOptionRepo;
        _imageRepo = imageRepo;
        _priceRepo = priceRepo;
    }

    public IDataResult<GnlProduct> AddProduct(GnlProduct product)
    {
        var result = _productRepo.Add(product);
        return new SuccessDataResult<GnlProduct>(result);
    }

    public IDataResult<ProductMasterModelDto> AddProduct(ProductMasterModelDto product)
    {
        throw new NotImplementedException();
    }

    public IResult DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlProduct> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlProduct> GetProduct(string upc = "", string ean = "", string jan = "", string isbn = "", string mpn = "", int statusId = 1)
    {
        throw new NotImplementedException();
    }

    public IDataResult<GnlProduct> GetProduct(int productId)
    {
        return _productRepo.GetProduct(productId);
    }
    public IDataResult<ProductMasterModelDto> GetProductMaster(int productId)
    {
        var product = _productRepo.GetProduct(productId).Data;
        if (product is null)
            return new ErrorDataResult<ProductMasterModelDto>(default, EntityConsts.DataNotFound);

        ProductMasterModelDto masterProduct = new ProductMasterModelDto();

        masterProduct.Id = productId;
        masterProduct.Name = product.Name;
        masterProduct.Description = product.Description;
        masterProduct.BrandId = product.BrandId;
        masterProduct.ManufacturerId = product.ManufacturerId;
        masterProduct.XmlId = product.XmlId;
        masterProduct.StatusId = product.StatusId;
        masterProduct.CategoryId = product.CategoryId;
        masterProduct.CreatedDate = product.CreatedDate;
        masterProduct.UpdatedDate = product.UpdatedDate;
        masterProduct.MinimumOrder = product.MinmumOrder;
        masterProduct.StockCode = product.StockCode;
        masterProduct.SellerCode = product.SellerCode;
        masterProduct.SellerUrl = product.SellerUrl;
        masterProduct.Mpn = product.Mpn;
        masterProduct.Ean = product.Ean;
        masterProduct.Jan = product.Jan;
        masterProduct.Isbn = product.Isbn;
        masterProduct.Upc = product.Upc;
        masterProduct.ProductOptions = new List<ProductOptionDto>();

        var options = _optionRepo.GetOptions(productId, (int)StatusTypes.All).Data;
        var prices = _priceRepo.GetPricesByProductId(productId).Data;
        var images = _imageRepo.GetImages(productId).Data;

        foreach (var option in options)
        {
            var price = prices.Where(x => x.OptionId == option.Id).FirstOrDefault();

            ProductOptionDto model = new ProductOptionDto()
            {
                Id = option.Id,
                OptionName = option.OptionName,
                StockCode = option.StockCode,
                StatusId = option.StatusId,
                Price = price.Price,
                PurchasePrice = price.PurchasePrice,
                VatRatioId = price.VatRatioId,
                IsSale = price.IsSale,
                DiscountPrice = price.DiscountPrice,
                DiscountRatio = price.DiscountRatio,
                DiscountExpireDate = price.DiscountExpireDate.ToString(),
                AvailableDate = option.AvailableDate.ToString(),
                CurrencyId = price.CurrencyId,
                IsAvailable = option.IsAvailable,
                UnitOfStock = option.UnitOfStock,
                UnitTypeId = option.UnitTypeId,
                Height = option.Height,
                Length = option.Length,
                Width = option.Width,
                Weight = option.Weight
            };

            if (images.Count > 0)
            {
                model.ProductImages = new string[images.Count];
                var image = images.Where(x => x.OptionId == option.Id).ToList();

                for (int i = 0; i < image.Count; i++)
                {
                    model.ProductImages[i] = image[i].ImageUrl;
                }
            }

            masterProduct.ProductOptions.Add(model);
        }

        return new SuccessDataResult<ProductMasterModelDto>(masterProduct);
    }

    public IListResult<ProductsModelDto> GetProducts(int categoryId = 0, int brandId = 0, int manufacturerId = 0, int xmlId = 0, int statusId = 1, int start = 0, int take = 25)
    {
        return _productRepo.GetProducts(categoryId, brandId, manufacturerId, xmlId, statusId, start, take);
    }

    public int GetProductsCount()
    {
        try
        {
            return _productRepo.GetCount<GnlProduct>();
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

}
