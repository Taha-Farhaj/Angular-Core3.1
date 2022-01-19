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
using CRM.DBCore.Repositories.Interfaces;
using CRM.DBCore.Uow;
using CRM.Models.Entities;
using CRM.Utilities.Hashing;
using CRM.Models.Command;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CRM.Models.ViewModel;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace CRM.Services.UsersService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private CRM.DBCore.Context.EFContext.DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public UserService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper, UserManager<ApplicationUser> userManager, IOptions<AppSettings> appSettings, RoleManager<IdentityRole> roleManager, CRM.DBCore.Context.EFContext.DatabaseContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _roleManager = roleManager;
            _context = context;
            _configuration = configuration;
        }
        public async Task<object> GetLogin(UserCommand parm)
        {
            Expression<Func<Employee, bool>> predicate = x => x.Username == parm.Username && x.Password == parm.Password;
            Expression<Func<Employee, object>>[] includes = {
                    x => x.EmployeeRoles,
                    //x => x.EmployeeRolesEmployee.First().Role,
                    //x => x.Product,
            };
            Expression<Func<Employee, object>> OrderBy = x => x.FirstName;
            var employee = GetRepository().GetFirstAsync(predicate, includes).Result;
            if(employee != null)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, employee.Username),
                    new Claim("UserId", employee.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in employee.EmployeeRoles)
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole.Role.RoleName));

                var appSettingsSection = _configuration.GetSection("AppSettings");
                var appSettings = appSettingsSection.Get<AppSettings>();

                var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                var authSigningKey = new SymmetricSecurityKey(key);

                var token = new JwtSecurityToken(
                    issuer: appSettings.Issure,// _configuration["JWT:ValidIssuer"],
                    audience: appSettings.ValidAudience,// _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                return new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    role = string.Join(",", employee.EmployeeRoles.Select(o => o.Role.RoleName)),
                    userName = employee.Username,
                    userId = employee.Id,
                    //OfficeId = user.OfficeId,
                    message = "Login Successfully"
                };
            }
            else
                return null;

            //var Users = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();

            //var users = await _userManager.Users.ToListAsync();
            //foreach (var v in users)
            //{
            //    var roles = await _userManager.GetRolesAsync(v);

            //}


            //var user = await _userManager.FindByNameAsync(model.UserName);
            //if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            //{
            //    var tokenDescriptor = new SecurityTokenDescriptor
            //    {
            //        Subject = new ClaimsIdentity(new Claim[]
            //        {
            //            new Claim("UserID",user.Id.ToString())
            //        }),
            //        Expires = DateTime.UtcNow.AddDays(1),
            //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret)), SecurityAlgorithms.HmacSha256Signature)
            //    };
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            //    var token = tokenHandler.WriteToken(securityToken);
            //    return new { token, user.Id };
            //}
            //else
            //{
            //    return new { message = "Username or password is incorrect." };
            //}
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
            Expression<Func<Employee, bool>> predicate = x => (parm.FirstName != null ? x.FirstName.Contains(parm.FirstName) : x.FirstName == x.FirstName)
            && (parm.Email != null ? x.Email.Contains(parm.Email) : x.Email == x.Email);
            Expression<Func<Employee, object>>[] includes = {
                    //x => x.Role,
                    //x => x.EmployeeRolesEmployee.First().Role,
                    //x => x.Product,
            };
            List<string> thenInclude = new List<string>();
            thenInclude.Add("EmplyeeAppAccesses.Site");
            thenInclude.Add("EmployeeRolesEmployee.Role");
            Expression<Func<Employee, object>> OrderBy = x => x.FirstName;
            _unitOfWork.GetRepository<Employee>().GetWhereAsync(predicate, parm.PagingData, OrderBy, null, thenInclude, null);
            return listOfApplication;
        }

        IGenericRepository<Employee> GetRepository()
        {
            return _unitOfWork.GetRepository<Employee>();
        }
        public Tuple<IEnumerable<UserVM>, long> GetAllUser(UserCommand parm)
        {
            Expression<Func<Employee, bool>> predicate = x => (parm.FirstName != null ? x.FirstName.Contains(parm.FirstName) : x.FirstName == x.FirstName)
            && (parm.LastName != null ? x.LastName.Contains(parm.LastName) : x.LastName == x.LastName)
            && (parm.Email != null ? x.Email.Contains(parm.Email) : x.Email == x.Email);
            Expression<Func<Employee, object>>[] includes = {
                    //x => x.Role,
                    //x => x.EmployeeRolesEmployee.First().Role,
                    //x => x.Product,
            };
            List<string> thenInclude = new List<string>();
            //thenInclude.Add("EmplyeeAppAccesses.Site");
            //thenInclude.Add("EmployeeRolesEmployee.Role");
            Expression<Func<Employee, object>> OrderBy = x => x.FirstName;
            var employeeList = _unitOfWork.GetRepository<Employee>().GetPagingWhereAsync(predicate, parm.PagingData, OrderBy, null, thenInclude, null);
            var emplyees = _mapper.Map<IEnumerable<UserVM>>(employeeList.Item1);
            return new Tuple<IEnumerable<UserVM>, long>(emplyees, employeeList.Item2);
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
                var result = _context.Users.Find(userId);
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

        public Employee GetUser(long id)
        {
            Expression<Func<Employee, bool>> predicate = x => x.Id == id;
            Expression<Func<Employee, object>>[] includes = {
                    x => x.EmployeeRoles,
                    x => x.EmplyeeAppAccess
            };
            return GetRepository().GetFirstAsync(predicate, includes).Result;
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
