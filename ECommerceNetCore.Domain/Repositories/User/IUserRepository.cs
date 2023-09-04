using ECommerce.Core.Persistance;

namespace ECommerce.User
{
    public interface IUserRepository : IBaseEntityRepository<GnlUser>
    {
        IListResult<GnlUser> GetAllUsers(int statusId = (int)StatusTypes.Active, int start = 0, int take = 25);
    }
}
