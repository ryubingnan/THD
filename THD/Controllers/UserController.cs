using AutoMapper;
using THD.Service.Dtos;
using THD.Service.Interfaces;
using THD.Web.Controllers.Abstract;
using THD.Web.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Volo.Abp;

namespace THD.Web.Controllers
{
    public class UserController : MvcControllerBase<UserController>
    {
        private readonly IUserAppService _userAppService;

        public UserController(
            ILogger<UserController> logger,
            IMapper mapper,
            IUserAppService userAppService)
            : base(logger, mapper)
        {
            _userAppService = userAppService;
        }

        public async Task<IActionResult> Index()
        {
            var users = (await _userAppService.GetListAsync()).ToList();

            var userModels = Mapper.Map<List<UserListItemViewModel>>(users);

            var model = new UserListViewModel()
            {
                Users = userModels
            };

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userAppService.GetAsync(id);

            var model = Mapper.Map<EditUserViewModel>(user);

            return PartialView("_Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dto = Mapper.Map<UpdateUserDto>(model);

            var user = await _userAppService.UpdateAsync(id, dto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var currentUserId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            if (currentUserId == id) throw new UserFriendlyException("Can't Remove Current User");

            await _userAppService.RemoveAsync(id);

            return Ok();
        }
    }
}
