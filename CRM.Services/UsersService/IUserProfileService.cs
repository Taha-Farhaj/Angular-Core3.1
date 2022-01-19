using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRM.Models.Entities;

namespace CRM.Services.UsersService
{
    public interface IUserProfileService
    {
        Task<ApplicationUser> GetProfile(string Id);
        Task<IdentityRole> GetUserRoles(string Id);
        Task<List<IdentityRole>> GetRolesList();
        Task<List<UserViewModel>> GetUsers();
        Task<UserViewModel> GetById(string Id);
        Task<ApplicationUser> UpdateUser(UserViewModel usermodel);

        bool UserExists(string id);
    }
}
