using BWC.Models.Entities;
using BWC.Services.BuyerService;
using BWC.Services.SocietyService;
using BWC.Services.StatusService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DealerPackagesWeb.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SocietyController : ControllerBase
    {
        private readonly ISocietyService _IntSocietyService;
        private readonly IStatusService _statusService;
        private readonly IBuyerService _buyerService;
        public SocietyController(ISocietyService _ISocietyService,
            IStatusService statusService,
            IBuyerService buyerService)
        {
            _IntSocietyService = _ISocietyService;
            _statusService = statusService;
            _buyerService = buyerService;
        }

        [HttpGet]
        public IActionResult GetAllSocieties()
        {
            try
            {
                var result = _IntSocietyService.GetRepository().GetAllAsync().Result;
                var data = new SelectList(result, "id", "title");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex });
            }
        }

        [HttpGet]
        public IActionResult GetAllStatus()
        {
            try
            {
                var result = _statusService.GetRepository().GetAllAsync().Result;
                var data = new SelectList(result, "Id", "Name");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex });
            }
        }

        [HttpGet]
        public IActionResult GetAllFiles(string RegNo)
        {
            try
            {
                var result = _IntSocietyService.GetAllFiles(RegNo);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something Went Wrongs" });
            }
        }

        [HttpGet]
        public IActionResult GetAllBuyer(string BuyerName)
        {
            try
            {
                var result = _IntSocietyService.GetAllBuyers(BuyerName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something Went Wrongs" });
            }
        }

    }
}
