using AutoMapper;

using THD.Service.Dtos;
using THD.Service.Interfaces;
using THD.Web.Controllers.Abstract;
using THD.Web.Models.Food;
using THD.Web.Models.User;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Volo.Abp;

namespace THD.Web.Controllers
{
    public class MyRoomController : MvcControllerBase<MyRoomController>
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IUserAppService _userAppService;

        public MyRoomController(
            ILogger<MyRoomController> logger,
            IMapper mapper,
            IWebHostEnvironment environment,
            IUserAppService userAppService)
            : base(logger, mapper)
        {
            _environment = environment;
            _userAppService = userAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> MemberInfo()
        {
            var userDto = await _userAppService.GetAsync(int.Parse(UserId));
            var userView = Mapper.Map<UserViewModel>(userDto);
            return View(userView);
        }

        [HttpPost]
        public async Task<IActionResult> MemberInfo([FromForm] UserViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            var userDto = await _userAppService.GetAsync(input.Id);
            if (userDto is null) throw new UserFriendlyException("找不到用户");
            userDto.Name = input.Name;
            userDto.Type = input.Type;
            userDto.Email = input.Email;
            userDto.Address = input.Address;
            userDto.QQ = input.QQ;
            userDto.WeChat = input.WeChat;
            userDto.GSMC = input.GSMC;
            userDto.GSDH = input.GSDH;
            userDto.GSYX = input.GSYX;
            userDto.GSCZ = input.GSCZ;
            userDto.GSDZ = input.GSDZ;
            var user = await _userAppService.EditAsync(userDto);
            var userView = Mapper.Map<UserViewModel>(user);
            return View(userView);
        }

        public async Task<IActionResult> Photo()
        {
            var userDto = await _userAppService.GetAsync(int.Parse(UserId));
            ViewBag.Id = userDto.Id;
            ViewBag.Pic = userDto.Pic;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Photo(int id, IFormFile fileImg)
        {
            var userDto = await _userAppService.GetAsync(id);
            if (userDto is null) throw new UserFriendlyException("找不到用户");
            if (fileImg is not null)
            {
                userDto.Pic = await GetFilePath(fileImg, "User", "Img" + id);
                userDto = await _userAppService.EditAsync(userDto);
            }
            ViewBag.Id = userDto.Id;
            ViewBag.Pic = userDto.Pic;
            return View();
        }

        public IActionResult PasswordChange()
        {
            return View(new UserPwdViewModel { Id = int.Parse(UserId) });
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(UserPwdViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            if (input.NewPassword != input.ConfirmePassword)
            {
                ModelState.AddModelError("ConfirmePassword", "输入密码不一致");
                return View(input);
            }
            var userDto = await _userAppService.GetAsync(input.Id);
            if (userDto is null) throw new UserFriendlyException("找不到用户");

            if (userDto.Password != input.OldPassword)
            {
                ModelState.AddModelError("OldPassword", "密码错误");
                return View(input);
            }

            userDto.Password = input.NewPassword;
            userDto = await _userAppService.EditAsync(userDto);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Quitters()
        {
            ViewBag.Id = UserId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Quitters(int id)
        {
            var userDto = await _userAppService.GetAsync(id);
            if (userDto is null) throw new UserFriendlyException("找不到用户");
            userDto.IsDelete = true;
            await _userAppService.EditAsync(userDto);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return new EmptyResult();
        }

        private async Task<string> GetFilePath(IFormFile file, string folderName, string symbol = "")
        {
            if (file is null) return "";
            var fileName = folderName + symbol + "_" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + Path.GetExtension(file.FileName);
            var uploadsRootFolder = Path.Combine(_environment.WebRootPath, "uploadfile", folderName);
            if (!Directory.Exists(uploadsRootFolder))
            {
                Directory.CreateDirectory(uploadsRootFolder);
            }
            var savePath = Path.Combine(uploadsRootFolder, fileName);
            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return savePath.Replace(_environment.WebRootPath, "").Replace("\\", "/");
        }
    }
}
