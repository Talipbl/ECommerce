using ECommerceNetCore.Application.Aspects;
using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services
{
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
        #region Product

        [LogAspect]
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
            throw new NotImplementedException();
        }

        public IListResult<GnlProduct> GetProducts(int categoryId = 0, int brandId = 0, int manufacturerId = 0, int xmlId = 0, int statusId = 1, bool onlyInStock = true, bool onlySale = false)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Product Image

        [LogAspect]
        public IDataResult<GnlProductImage> AddProductImage(GnlProductImage image)
        {
            var result = _imageRepo.Add(image);
            return new SuccessDataResult<GnlProductImage>(result);
        }

        public IResult DeleteProductImage(int id)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateProductImage(GnlProductImage image)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Product Price

        [LogAspect]
        public IDataResult<GnlProductPrice> AddProductPrice(GnlProductPrice price)
        {
            var result = _priceRepo.Add(price);
            return new SuccessDataResult<GnlProductPrice>(result);
        }

        public IResult DeleteProductPrice(int id)
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlProductPrice> GetAllProductPrice()
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlProductPrice> GetProductPrices(int productId, int optionId = 0, bool onlySale = false, int statusId = 1)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateProductPrice(GnlProductPrice price)
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlProductPrice> GetProductPrice(int priceId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Product Option

        [LogAspect]
        public IDataResult<GnlProductOption> AddProductOption(GnlProductOption option)
        {
            var result = _optionRepo.Add(option);
            return new SuccessDataResult<GnlProductOption>(result);
        }

        public IResult DeleteProductOption(int id)
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlProductOption> GetAllProductOption()
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlProductOption> GetProductOption(int optionId)
        {
            throw new NotImplementedException();
        }

        public IListResult<GnlProductOption> GetProductOptions(int productId, int statusId = 1)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateProduct(GnlProduct product)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateProductOption(GnlProductOption option)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
