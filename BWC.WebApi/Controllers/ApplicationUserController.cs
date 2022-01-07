using BWC.Services.UsersService;
using BWC.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BWC.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public ApplicationUserController(IUserService userService ,
            IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
             
        }

        [HttpGet]
        public IActionResult GetAllRole()
        {
            try
            {
                List<RoleList> result = new List<RoleList>();
                result = _userService.GetAllRole();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Something Went Wrong" });
            }
        }

        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                List<UserList> result = new List<UserList>();
                result = _userService.GetAllUser();
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Something Went Wrong" });
            }
        }

        [HttpGet]
        public IActionResult DeleteUser(string UserId)
        {
            try
            {
                var result = _userService.DeleteUser(UserId);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Something Went Wrong" });
            }
        }

        
    }
}
