using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BWC.DBCore.Repositories.Interfaces;
using BWC.DBCore.Uow;
using BWC.Models.Entities;
using BWC.Utilities.Hashing;
using BWC.Models.Command;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using BWC.Models.ViewModel;

namespace BWC.Services.UsersService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly AppSettings _appSettings;
        private BWC.DBCore.Context.EFContext.DatabaseContext _context;
        public UserService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, IOptions<AppSettings> appSettings, RoleManager<IdentityRole> roleManager, BWC.DBCore.Context.EFContext.DatabaseContext context)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _roleManager= roleManager;
            _context = context;
        }
        public async Task<object> GetLogin(LoginViewModel model)
        {
            //var Users = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();

            var users = await _userManager.Users.ToListAsync();
            foreach (var v in users)
            {
                var roles = await _userManager.GetRolesAsync(v);
            
            }


            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return new { token, user.Id };
            }
            else {
                return new { message = "Username or password is incorrect." };
            }
        }

        public async Task<object> GetRegister(ApplicationUserModel model)
        {
            try
            {
                var applicationUser = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FullName = model.FullName
                };
                var result = await _userManager.CreateAsync(applicationUser, model.Password);

                var adminresult = await createRolesandUsers();
                //Add user to Role User
                if (adminresult)
                {
                    var result1 = _userManager.AddToRoleAsync(applicationUser, "User");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ApplicationUser> FindUser(UserCommand parm)
        {
            List<ApplicationUser> listOfApplication = new List<ApplicationUser>();
            Expression<Func<ApplicationUser, bool>> predicate = x => (parm.Name != null ? x.FullName.Contains(parm.Name) : x.FullName == x.FullName)
            && (parm.Email != null ? x.Email.Contains(parm.Email) : x.Email == x.Email);
            Expression<Func<ApplicationUser, object>>[] includes = {
                    //x => x.Category,
                    //x => x.App,
                    //x => x.Product,
            };
            Expression<Func<ApplicationUser, object>> OrderBy = x => x.FullName;
            _unitOfWork.GetRepository<ApplicationUser>().GetWhereAsync(predicate, null, OrderBy, null, null, includes);
            return listOfApplication;
        }

        IGenericRepository<ApplicationUser> GetRepository()
        {
            return _unitOfWork.GetRepository<ApplicationUser>();
        }
        public List<UserList> GetAllUser()
        {
            try
            {
                var result = (from user in _context.Users
                              join userRoles in _context.UserRoles
                              on user.Id equals userRoles.UserId
                              join roles in _context.Roles
                              on userRoles.RoleId equals roles.Id
                              //join office in _context.Office
                              //on user.OfficeId equals office.Id
                              select new UserList
                              {
                                  UserId = user.Id,
                                  UserName = user.FullName,
                                  Email = user.Email,
                                  RoleId = roles.Id,
                                  RoleName = roles.Name,
                                  //OfficeId = office.Id,
                                  //OfficeName = office.Name,
                                  //Password = user.PasswordHash,
                                  //ConfirmPassword = user.PasswordHash
                              }).ToList();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<RoleList> GetAllRole()
        {
            try
            {
                var result = (from roles in _context.Roles
                              select new RoleList
                              {
                                  RoleId = roles.Id,
                                  Name = roles.Name
                              }).ToList();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteUser(string userId)
        {
            try
            {
                var result =  _context.Users.Find(userId);
                if (result != null)
                {
                    _context.Users.Remove(result);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        // In this method we will create default User roles and Admin user for login   
        #region roles
        private async Task<bool> createRolesandUsers()
        {
            var result = false;
            try
            {
                bool x = await _roleManager.RoleExistsAsync("Admin");
                if (!x)
                {
                    // first we create Admin rool    
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    await _roleManager.CreateAsync(role);

                    //Here we create a Admin super user who will maintain the website                   

                    var user = new ApplicationUser();
                    user.UserName = "admin@gmail.com";
                    user.Email = "admin@gmail.com";
                    user.FullName = "Admin";
                    string userPWD = "Admin123";

                    IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);
                    //Add default User to Role Admin    
                    if (chkUser.Succeeded)
                    {
                        var result1 = await _userManager.AddToRoleAsync(user, "Admin");
                    }
                }

                // creating Creating Manager role     
                x = await _roleManager.RoleExistsAsync("User");
                if (!x)
                {
                    var role = new IdentityRole();
                    role.Name = "User";
                    await _roleManager.CreateAsync(role);
                }
                result = true;
                return result;
            }
            catch (Exception)
            {
                result = false;
                throw;
            }
            return true;
        }

        IGenericRepository<ApplicationUser> IUserService.GetRepository()
        {
            throw new NotImplementedException();
        }

        



        #endregion
    }
}
