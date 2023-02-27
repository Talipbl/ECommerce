using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IProductImageRepository : IBaseEntityRepository<GnlProductImage>
    {
        IListResult<GnlProductImage> GetIamges(int optionId);
    }
}
