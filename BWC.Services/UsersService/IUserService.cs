using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BWC.DBCore.Repositories.Interfaces;
using BWC.Models.Entities;
using BWC.Models.Command;
using BWC.Models.ViewModel;

namespace BWC.Services.UsersService
{
    public interface IUserService
    {
        Task<Object> GetLogin(LoginViewModel applicationUser);
        Task<Object> GetRegister(ApplicationUserModel applicationUser);
        IGenericRepository<ApplicationUser> GetRepository();
        List<ApplicationUser> FindUser(UserCommand parm);

        List<UserList> GetAllUser();
        List<RoleList> GetAllRole();
        bool DeleteUser(string userId);
    }
}
