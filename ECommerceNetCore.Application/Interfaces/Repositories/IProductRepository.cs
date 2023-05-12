using ECommerceNetCore.Application.DataTransferObjects;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IProductRepository : IBaseEntityRepository<GnlProduct>
    {
        IDataResult<GnlProduct> GetProduct(string productName);
        IDataResult<GnlProduct> GetProduct(int productId);
        IListResult<ProductsModelDto> GetProducts(int categoryId = 0, int brandId = 0, int manufacturerId = 0, int xmlId = 0, int statusId = 1, int start = 0, int take = 25);
    }
}
