using ECommerce.Core.Application;

namespace ECommerce.User;

public interface IUserService
{
    IDataResult<GnlUser> AddUser(GnlUser user);
    IResult UpdateUser(GnlUser user);
    IResult DeleteUser(int id);
    IListResult<GnlUser> GetAllUsers(int statudId = (int)StatusTypes.Active, int start = 0, int take = 25);
    IDataResult<GnlUser> GetUser(string userName, string userMail);
}
