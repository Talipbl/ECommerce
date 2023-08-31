using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Common;
using ECommerceNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IAdminService
    {
        IDataResult<DefAdmin> AddAdmin(DefAdmin admin);
        IResult UpdateAdmin(DefAdmin admin);
        IResult DeleteAdmin(int adminId);
        IListResult<DefAdmin> GetAdmins(int statusId = (int)StatusTypes.Active);
        IDataResult<DefAdmin> GetAdmin(int adminId);
        IDataResult<DefAdmin> GetAdmin(string nameOrMail);
    }
}
