using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DBCore.Context.EFContext;
using CRM.Models.Entities;

namespace CRM.Services.UsersService
{
    public class UserProfileService : IUserProfileService
    {
        private DatabaseContext _dbContext;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserProfileService(UserManager<ApplicationUser> userManager, DatabaseContext dbContext, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _dbContext = dbContext;
            _roleManager = roleManager;
        }
        public async  Task<UserViewModel> GetById(string Id)
        {
            try
            {
                var user = _dbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
                var userVm = new UserViewModel();
                if (user != null)
                {
                    var userRole = _dbContext.UserRoles.Where(u => u.UserId == user.Id).FirstOrDefault();
                    var role = _dbContext.Roles.Where(r => r.Id == userRole.RoleId).FirstOrDefault();
                    userVm.UserId = user.Id;
                    userVm.UserName = user.UserName;
                    userVm.Email = user.Email;
                    userVm.FullName = user.FullName;
                    userVm.RoleId = userRole.RoleId;
                    userVm.RoleName = role.Name;
                }
                return userVm;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ApplicationUser> GetProfile(string Id)
        {
            //try
            //{
            //    var user = _dbContext.ApplicationUsers.Where(x => x.Id == Id).FirstOrDefault();
            //    var application = new ApplicationUser();
            //    if (user != null)
            //    {
            //        application.UserName = user.UserName;
            //        application.Email = user.Email;
            //        application.FullName = user.FullName;
            //    }
            //    return application;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return null;
            
        }

        public async Task<IdentityRole> GetUserRoles(string Id)
        {
            try
            {
                var userRole = _dbContext.UserRoles.Where(x => x.UserId == Id).FirstOrDefault();
                var role = new IdentityRole();
                if (userRole != null)
                {
                    role = await _roleManager.FindByIdAsync(userRole.RoleId);
                    
                }
                return role;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public async Task<List<IdentityRole>> GetRolesList()
        {
            try
            {
                var role = _dbContext.Roles.ToList();
                return role;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<List<UserViewModel>> GetUsers()
        {
            try
            {
                var list = _dbContext.Users.ToList();
                List<UserViewModel> listVM = new List<UserViewModel>();
                foreach (var item in list)
                {
                    UserViewModel obj = new UserViewModel();
                    var userRole = _dbContext.UserRoles.Where(u => u.UserId == item.Id).FirstOrDefault();
                    var role = _dbContext.Roles.Where(r => r.Id == userRole.RoleId).FirstOrDefault();
                    obj.UserId = item.Id;
                    obj.UserName = item.UserName;
                    obj.Email = item.Email;
                    obj.FullName = item.FullName;
                    obj.RoleId = userRole.RoleId;
                    obj.RoleName = role.Name;
                    listVM.Add(obj);
                }
                return listVM;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ApplicationUser> UpdateUser(UserViewModel usermodel)
        {
            //try
            //{
            //    var userdetail = _dbContext.ApplicationUsers.Where(u => u.Id == usermodel.UserId).FirstOrDefault();
            //    if (userdetail != null)
            //    {
            //        var userrole = _dbContext.UserRoles.Where(ur => ur.UserId == userdetail.Id).FirstOrDefault();
            //        userdetail.FullName =usermodel.FullName;
            //        userdetail.Email = usermodel.Email;
            //        userdetail.UserName = usermodel.UserName;
            //        //updating user 
            //        _dbContext.Entry(userdetail).State = EntityState.Modified;
            //        _dbContext.SaveChangesAsync();
            //        //updating role
            //        //if (userrole.RoleId != usermodel.RoleId)
            //        //{
            //        //    await _userManager.RemoveFromRoleAsync(userdetail, userrole.RoleId);
            //        //    await _userManager.AddToRoleAsync(userdetail, );
            //        //}
            //        //userrole.RoleId = usermodel.RoleId;
            //        //_dbContext.Entry(userrole).State = EntityState.Modified;
            //        //_dbContext.SaveChangesAsync();
            //    }
            //    return userdetail;
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    throw;
            //}
            return null;

        }

        public bool UserExists(string id)
        {
            return _dbContext.Users.Any(e => e.Id == id);
        }
    }
}
