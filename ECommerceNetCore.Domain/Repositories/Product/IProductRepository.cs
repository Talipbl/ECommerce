using ECommerce.Application.DataTransferObjects.Products;
using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Repositories.Product
{
    public interface IProductRepository : IBaseEntityRepository<GnlProduct>
    {
        IDataResult<GnlProduct> GetProduct(string productName);
        IDataResult<GnlProduct> GetProduct(int productId);
        IListResult<ProductsModelDto> GetProducts(int categoryId = 0, int brandId = 0, int manufacturerId = 0, int xmlId = 0, int statusId = 1, int start = 0, int take = 25);
    }
}
