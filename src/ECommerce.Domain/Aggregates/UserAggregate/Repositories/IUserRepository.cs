using ECommerce.Domain;

namespace ECommerce.User
{
    public interface IUserRepository : IBaseEntityRepository<GnlUser>
    {
        ICollection<GnlUser> GetAllUsers(int statusId = 1, int start = 0, int take = 25);
    }
}
