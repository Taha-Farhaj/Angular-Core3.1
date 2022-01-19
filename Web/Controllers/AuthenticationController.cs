using CRM.Models.Command;
using CRM.Models.Entities;
using CRM.Services.UsersService;
using CRM.Utilities;
using CRM.Utilities.Hashing;
using CRM.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IUserService userService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserCommand model)
        {
            model.Password = Util.Hash(model.Password);
            var employee = _userService.GetLogin(model).Result;
            if (employee != null)
            {
                return Ok(employee);
                //var userRoles = await userManager.GetRolesAsync(user); 

                //var authClaims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Name, user.UserName),
                //    new Claim("UserId", user.Id),
                //    //new Claim("OfficeId", user.OfficeId.ToString()),
                //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //};

                //foreach (var userRole in userRoles)
                //{
                //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                //}

                //var appSettingsSection = _configuration.GetSection("AppSettings");
                //var appSettings = appSettingsSection.Get<AppSettings>();

                //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                //var authSigningKey = new SymmetricSecurityKey(key);

                //var token = new JwtSecurityToken(
                //    issuer: appSettings.Issure,// _configuration["JWT:ValidIssuer"],
                //    audience: appSettings.ValidAudience,// _configuration["JWT:ValidAudience"],
                //    expires: DateTime.Now.AddHours(3),
                //    claims: authClaims,
                //    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                //    );

                //return Ok(new
                //{
                //    token = new JwtSecurityTokenHandler().WriteToken(token),
                //    expiration = token.ValidTo,
                //    role = userRoles.FirstOrDefault().ToString(),
                //    userName = user.Email == null ? user.UserName : user.Email,
                //    userId = user.Id,
                //    //OfficeId = user.OfficeId,
                //    message = "Login Successfully"
                //});
            }
            else
                return Unauthorized(new { message = "Username and password does not match" });
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserViewModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                FullName = model.FullName,
                //OfficeId = model.OfficeId
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            if (UserRoles.Admin == model.RoleName)
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            else if (UserRoles.User == model.RoleName)
            {
                await userManager.AddToRoleAsync(user, UserRoles.User);
            }
            else
            {
                return BadRequest(new { message = "User Role is Not Match" });
            }

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }


        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody] UserViewModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Not exists!" });
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.FullName = model.FullName;
            //user.OfficeId = model.OfficeId;

            var userData = await userManager.FindByNameAsync(model.UserName);
            var currentRoles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, currentRoles);

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Updatation failed! Please check user details and try again." });

            if (UserRoles.Admin == model.RoleName)
            {
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            else if (UserRoles.User == model.RoleName)
            {
                await userManager.AddToRoleAsync(user, UserRoles.User);
            }
            else
            {
                return BadRequest(new { message = "User Role is Not Match" });
            }
            return Ok(new Response { Status = "Success", Message = "User Updated successfully!" });
        }

        [HttpPost]
        public async Task<IActionResult> ResetUserPassword([FromBody] PasswordResetCommand model)
        {
            try
            {
                var User = await userManager.FindByIdAsync(model.UserId);
                var token = await userManager.GeneratePasswordResetTokenAsync(User);
                var result = await userManager.ResetPasswordAsync(User, token, model.NewPassword);

                return Ok(new Response { Status = "Success", Message = "Password Reset successfully!" });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
