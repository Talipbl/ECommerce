using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;
using Microsoft.Data.SqlClient;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfProductRepository : EfBaseEntityRepository<GnlProduct, EcommerceNetCoreContext>, IProductRepository
    {
        public IDataResult<GnlProduct> GetProduct(string productName)
        {
            var result = this.Get(x => x.Name == productName);
            return new SuccessDataResult<GnlProduct>(result);
        }

        public IDataResult<GnlProduct> GetProduct(int productId)
        {
            var result = this.Get(x => x.Id == productId);
            return new SuccessDataResult<GnlProduct>(result);
        }

        public IListResult<ProductsModelDto> GetProducts(int categoryId = 0, int brandId = 0, int manufacturerId = 0, int xmlId = 0, int statusId = 1, int start = 0, int take = 25)
        {
            var result = this.GetAll(x => (categoryId != 0 ? x.CategoryId == categoryId : x.CategoryId != categoryId) &&
            (brandId != 0 ? x.BrandId == brandId : x.BrandId != brandId) &&
            (manufacturerId != 0 ? x.ManufacturerId == manufacturerId : x.ManufacturerId != manufacturerId) &&
            (xmlId != 0 ? x.XmlId == xmlId : x.XmlId != xmlId) &&
            (statusId != 0 ? x.StatusId == statusId : x.StatusId != statusId), x => x.Id, (int)SortOrder.Ascending, start, take, a => a.Brand, b => b.Manufacturer, c => c.Category, d => d.Status).Select(x => new ProductsModelDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                CategoryId = x.CategoryId,
                Category = x.Category.CategoryName,
                BrandId = x.BrandId,
                Brand = x.Brand.BrandName,
                ManufacturerId = x.ManufacturerId,
                Manufacturer = x.Manufacturer.ManufacturersName,
                StockCode = x.StockCode,
                Ean = x.Ean,
                Isbn = x.Isbn,
                Jan = x.Jan,
                Mpn = x.Mpn,
                Upc = x.Upc,
                SellerCode = x.SellerCode,
                SellerUrl = x.SellerUrl,
                StatusId = x.StatusId,
                Status = x.Status.StatusName,
                XmlId = x.XmlId,
                MinmumOrder = x.MinmumOrder,
            }).ToList();

            var count = this.GetAll(x => (categoryId != 0 ? x.CategoryId == categoryId : x.CategoryId != categoryId) &&
            (brandId != 0 ? x.BrandId == brandId : x.BrandId != brandId) &&
            (manufacturerId != 0 ? x.ManufacturerId == manufacturerId : x.ManufacturerId != manufacturerId) &&
            (xmlId != 0 ? x.XmlId == xmlId : x.XmlId != xmlId) &&
            (statusId != 0 ? x.StatusId == statusId : x.StatusId != statusId)).Count();

            return new ListResult<ProductsModelDto>(result, count);
        }
    }
}
