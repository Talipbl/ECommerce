using ECommerceNetCore.Application.Interfaces.Services;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services.Concretes
{
    public class ProductService : IProductService
    {
        #region Product
        public IDataResult<GnlProduct> AddProduct(GnlProduct product)
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
        public IDataResult<GnlProductImage> AddProductImage(GnlProductImage image)
        {
            throw new NotImplementedException();
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
        public IDataResult<GnlProductPrice> AddProductPrice(GnlProductPrice price)
        {
            throw new NotImplementedException();
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
        public IDataResult<GnlProductOption> AddProductOption(GnlProductOption option)
        {
            throw new NotImplementedException();
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
