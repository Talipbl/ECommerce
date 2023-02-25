using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IProductRepository : IBaseEntityRepository<GnlProduct>
    {
        IDataResult<GnlProduct> GetProduct(string productName);
    }
}
