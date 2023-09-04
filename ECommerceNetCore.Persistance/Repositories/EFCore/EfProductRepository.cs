using ECommerce.Core.Persistance;
using ECommerce.Persistance;
using Microsoft.Data.SqlClient;

namespace ECommerce.Product;

public class EfProductRepository : EfBaseEntityRepository<GnlProduct, ECommerceContext>, IProductRepository
{
    public GnlProduct GetProduct(string productName)
    {
        var result = Get(x => x.Name == productName);
        return result;
    }

    public GnlProduct GetProduct(int productId)
    {
        var result = Get(x => x.Id == productId);
        return result;
    }

    public ICollection<GnlProduct> GetProducts(int categoryId = 0, int brandId = 0, int manufacturerId = 0, int xmlId = 0, int statusId = 1, int start = 0, int take = 25)
    {
        var result = GetAll(x => (categoryId != 0 ? x.CategoryId == categoryId : x.CategoryId != categoryId) &&
        (brandId != 0 ? x.BrandId == brandId : x.BrandId != brandId) &&
        (manufacturerId != 0 ? x.ManufacturerId == manufacturerId : x.ManufacturerId != manufacturerId) &&
        (xmlId != 0 ? x.XmlId == xmlId : x.XmlId != xmlId) &&
        (statusId != 0 ? x.StatusId == statusId : x.StatusId != statusId), x => x.Id, (int)SortOrder.Ascending, start, take, a => a.Brand, b => b.Manufacturer, c => c.Category, d => d.Status).Select(x => new GnlProduct
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate,
            CategoryId = x.CategoryId,
            BrandId = x.BrandId,
            ManufacturerId = x.ManufacturerId,
            StockCode = x.StockCode,
            Ean = x.Ean,
            Isbn = x.Isbn,
            Jan = x.Jan,
            Mpn = x.Mpn,
            Upc = x.Upc,
            SellerCode = x.SellerCode,
            SellerUrl = x.SellerUrl,
            StatusId = x.StatusId,
            XmlId = x.XmlId,
            MinmumOrder = x.MinmumOrder
        }).ToList();

        var count = GetAll(x => (categoryId != 0 ? x.CategoryId == categoryId : x.CategoryId != categoryId) &&
        (brandId != 0 ? x.BrandId == brandId : x.BrandId != brandId) &&
        (manufacturerId != 0 ? x.ManufacturerId == manufacturerId : x.ManufacturerId != manufacturerId) &&
        (xmlId != 0 ? x.XmlId == xmlId : x.XmlId != xmlId) &&
        (statusId != 0 ? x.StatusId == statusId : x.StatusId != statusId)).Count();

        return result;
    }
}
