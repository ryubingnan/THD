using AutoMapper;
using THD.Web.Controllers.Abstract;
using THD.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using THD.Web.Models.Home;
using FluentEmail.Core;
using System.IO;
using System.Threading.Tasks;
using THD.Service.Interfaces;
using THD.Service.Dtos;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Http;

namespace THD.Web.Controllers
{
    public class HomeController : MvcControllerBase<HomeController>
    {
        private readonly IFluentEmail _fluentEmail;
        private readonly ITechnicianAppService _technicianAppService;
        private readonly IWebHostEnvironment _environment;
        public HomeController(ILogger<HomeController> logger, IMapper mapper,
            IFluentEmail fluentEmail,
            ITechnicianAppService technicianAppService,
            IWebHostEnvironment environment)
            : base(logger, mapper)
        {
            _fluentEmail = fluentEmail;
            _technicianAppService = technicianAppService;
            _environment = environment;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Message()
        {
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> TechnicianRegister([FromForm] TechnicianRegisterModel registerModel)
        {
            var technicianDto = Mapper.Map<TechnicianDto>(registerModel);
            if (registerModel.WorkExperience is not null)
                technicianDto.WorkExperienceFilePath = await GetFilePath(registerModel.WorkExperience, "Technician");
            await _technicianAppService.CreateAsync(technicianDto);
            var email = _fluentEmail.To("tohoweb@hotmail.com")
                .Subject("注册信息")
                .UsingTemplateFromFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/templates/TechnicianRegisterEmailTemp.cshtml"), registerModel);
            if (registerModel.WorkExperience is not null)
            {
                email.Attach(new FluentEmail.Core.Models.Attachment
                {
                    Data = registerModel.WorkExperience.OpenReadStream(),
                    Filename = registerModel.WorkExperience.FileName,
                    ContentType = registerModel.WorkExperience.ContentType
                });
            }
            await email.SendAsync();

            return RedirectToAction("Message", "Home");
        }

        private async Task<string> GetFilePath(IFormFile file, string folderName, string symbol = "")
        {
            try
            {
                if (file is null) return "";
                if (!string.IsNullOrEmpty(folderName)) folderName = folderName.ToLower();
                if (!string.IsNullOrEmpty(symbol)) symbol = symbol.ToLower();
                var fileName = folderName + symbol + "_" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + Path.GetExtension(file.FileName);
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "uploadfile", folderName);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }
                var savePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = System.IO.File.Create(savePath))
                {
                    await file.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                }
                return savePath.Replace(_environment.WebRootPath, "").Replace("\\", "/");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return "";
            }

        }
    }
}
