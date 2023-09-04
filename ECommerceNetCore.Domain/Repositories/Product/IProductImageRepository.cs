using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Repositories.Product
{
    public interface IProductImageRepository : IBaseEntityRepository<GnlProductImage>
    {
        IListResult<GnlProductImage> GetImages(int productId);
        IDataResult<GnlProductImage> GetImage(string filename);
    }
}
