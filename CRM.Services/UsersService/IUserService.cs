using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DBCore.Repositories.Interfaces;
using CRM.Models.Entities;
using CRM.Models.Command;
using CRM.Models.ViewModel;

namespace CRM.Services.UsersService
{
    public interface IUserService
    {
        Task<Object> GetLogin(UserCommand applicationUser);
        Task<Object> GetRegister(ApplicationUserModel applicationUser);
        IGenericRepository<ApplicationUser> GetRepository();
        List<ApplicationUser> FindUser(UserCommand parm);
        Employee GetUser(long id);
        Tuple<IEnumerable<UserVM>, long> GetAllUser(UserCommand parm);
        List<RoleList> GetAllRole();
        bool DeleteUser(string userId);
    }
}
