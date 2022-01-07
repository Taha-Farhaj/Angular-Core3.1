using BWC.Models.Command;
using BWC.Models.Entities;
using BWC.Services.Files;
using BWC.Services.TransferService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BWC.WebApi.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransferController : ControllerBase
    {

        private readonly ITransferService _IntTransferService;
          private readonly IFileService _fileService;
       
        public TransferController(IFileService fileService,
            ITransferService _ITransferService)
        {
            _fileService = fileService;
             _IntTransferService = _ITransferService;
        }
      

        [HttpGet]
        public IActionResult GetAllTransfer()
        {
            try
            {
                var result = _IntTransferService.GetRepository().GetAll(x=> x.IsActive == true && x.IsDeleted == false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex });
            }
        }

        [HttpGet]
        public IActionResult getTransferById(long TransferId)
        {
            try
            {
                var data = _IntTransferService.GetTransferById(TransferId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpPost]
        public IActionResult AddTransfer(TransferCommand model)
        {
            try
            {
                model.UserId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId").Value;
                var result = _IntTransferService.AddTransfer(model).Result;
                return Ok(new 
                { 
                    TransferId = result,
                    message = "Transfer Added Successfully"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost]
        public IActionResult FilesUploaded()
        {
            try
            {
               
                var file = Request.Form.Files[0];
                var result = JsonConvert.DeserializeObject<FilesCommand>(Request.Form["FileType"]);
                _IntTransferService.FilesUpload(file, result);
                return Ok(new { message = "File Uplaoded Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

    }
}
