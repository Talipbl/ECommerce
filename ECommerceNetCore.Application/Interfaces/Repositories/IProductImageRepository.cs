using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IProductImageRepository : IBaseEntityRepository<GnlProductImage>
    {
        IListResult<GnlProductImage> GetImages(int productId);
        IDataResult<GnlProductImage> GetImage(string filename);
    }
}
