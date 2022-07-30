using AutoMapper;
using FluentEmail.Core;
using THD.Service.Dtos;
using THD.Service.Interfaces;
using THD.Web.Controllers.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace THD.Web.Controllers
{
    public class AccountController : MvcControllerBase<AccountController>
    {
        private readonly IUserAppService _userAppService;
        private readonly LinkGenerator _linkGenerator;

        public AccountController(
            ILogger<AccountController> logger,
            IMapper mapper,
            IUserAppService userAppService,
            LinkGenerator linkGenerator)
            : base(logger, mapper)
        {
            _userAppService = userAppService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login([FromQuery] string returnUrl = "")
        {
            var model = new UserLoginQuery
            {
                ReturnUrl = returnUrl,
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task Login([FromBody] UserLoginQuery input)
        {
            var user = await _userAppService.LoginAsync(input);

            await LoginAsync(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task Register([FromBody] RegisterUserDto input, [FromServices] IFluentEmail singleEmail)
        {
            input.EmailConfirmeToken = Guid.NewGuid().ToString("N");

            var user = await _userAppService.RegisterAsync(input);

            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(EmailVerification), "Account",
                values: new { token = input.EmailConfirmeToken })
                + $"?email={input.Email}";
            var model = new VerifyEmailDto()
            {
                UserName = input.UserName,
                Url = url
            };

            var email = singleEmail.To(input.Email)
                .Subject("富士畅游邮箱验证")
                .UsingTemplateFromFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/templates/EmailVerification.cshtml"), model);

            await email.SendAsync();

            await LoginAsync(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterSuccess()
        {
            return View();
        }

        [HttpGet("[controller]/[action]/{token}")]
        [AllowAnonymous]
        public async Task<IActionResult> EmailVerification([FromRoute] string token, [FromQuery] string email)
        {
            var dto = new EmailVericationDto();

            var user = await _userAppService.VerifyEmailAsync(token, email);
            if (user is null)
            {
                dto.Error = "无效的验证";
            }
            else
            {
                dto.UserName = user.UserName;
                dto.Email = user.Email;
            }

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Forbidden()
        {
            return Content("Forbidden");
        }

        [NonAction]
        private async Task LoginAsync(UserDto user)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Type));
            if (user.UserName == "Admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            }

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
            {
                // 持久化token
                IsPersistent = true,
                // 过期时间为20分钟
                ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
            });
        }
    }
}
