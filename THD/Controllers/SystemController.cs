using AutoMapper;

using THD.Service.Dtos;
using THD.Service.Dtos.Users;
using THD.Service.Interfaces;
using THD.Web.Controllers.Abstract;
using THD.Web.Core.Options;
using THD.Web.Models.Food;
using THD.Web.Models.Guide;
using THD.Web.Models.Pickup;
using THD.Web.Models.Play;
using THD.Web.Models.Stay;
using THD.Web.Models.Ticket;
using THD.Web.Models.Tour;
using THD.Web.Models.User;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace THD.Web.Controllers
{
    public class SystemController : MvcControllerBase<SystemController>
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ITourAppService _tourAppService;
        private readonly IStayAppService _stayAppService;
        private readonly ITicketAppService _ticketAppService;
        private readonly IFoodAppService _foodAppService;
        private readonly IPickupAppService _pickupAppService;
        private readonly IGuideAppService _guideAppService;
        private readonly IPlayAppService _playAppService;
        private readonly IUserAppService _userAppService;
        private readonly ITechnicianAppService _technicianAppService;
        private readonly IItListInfoAppService _itListInfoAppService;
        private readonly ICorporateAppService _corporateAppService;

        public SystemController(
            ILogger<SystemController> logger,
            IMapper mapper,
            IWebHostEnvironment environment,
            ITourAppService tourAppService,
            IStayAppService stayAppService,
            ITicketAppService ticketAppService,
            IFoodAppService foodAppService,
            IPickupAppService pickupAppService,
            IGuideAppService guideAppService,
            IPlayAppService playAppService,
            IUserAppService userAppService,
            ITechnicianAppService technicianAppService,
            IItListInfoAppService itListInfoAppService,
            ICorporateAppService corporateAppService)
            : base(logger, mapper)
        {
            _environment = environment;
            _tourAppService = tourAppService;
            _stayAppService = stayAppService;
            _ticketAppService = ticketAppService;
            _foodAppService = foodAppService;
            _pickupAppService = pickupAppService;
            _guideAppService = guideAppService;
            _playAppService = playAppService;
            _userAppService = userAppService;
            _technicianAppService = technicianAppService;
            _itListInfoAppService = itListInfoAppService;
            _corporateAppService = corporateAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region 案件发布

        public IActionResult AddItListInfo(int? id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<ItListInfoDto> GetItListInfo([FromBody] int id)
        {
            return await _itListInfoAppService.GetAsync(id);
        }

        [HttpPost]
        public async Task<bool> AddItListInfo([FromBody] ItListInfoDto input)
        {
            input.user = this.UserId;
            input.update = DateTime.Now.ToString();
            var id = await _itListInfoAppService.AddOrEditAsync(input);
            if (id <= 0) throw new Exception("案件发布失败");
            return true;
        }

        public IActionResult ItListInfoList()
        {
            return View();
        }

        [HttpPost]
        public async Task<PagedResultDto<ItListInfoDto>> GetItListInfoList([FromBody] ItListInfoPagedQueryDto input)
        {
            var dtos = await _itListInfoAppService.GetListAsync(input);
            return dtos;
        }

        [HttpPost]
        public async Task<bool> DeleteItListInfo([FromBody] int id)
        {
            return await _itListInfoAppService.DeleteAsync(id);
        }

        #endregion

        #region 住宿发布

        public async Task<IActionResult> AddStay(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var stay = await _stayAppService.GetAsync(id.Value);
                var stayView = Mapper.Map<StayViewModel>(stay);
                return View(stayView);
            }
            return View(new StayViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddStay([FromForm] StayViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            var stayDto = Mapper.Map<StayDto>(input);
            if (input.FileImg1 is not null)
                stayDto.Img1 = await GetFilePath(input.FileImg1, "Stay", "Img1");
            if (input.FileImg2 is not null)
                stayDto.Img2 = await GetFilePath(input.FileImg2, "Stay", "Img2");
            if (input.FileImg3 is not null)
                stayDto.Img3 = await GetFilePath(input.FileImg3, "Stay", "Img3");
            if (input.FileImg4 is not null)
                stayDto.Img4 = await GetFilePath(input.FileImg4, "Stay", "Img4");
            if (input.FileImg5 is not null)
                stayDto.Img5 = await GetFilePath(input.FileImg5, "Stay", "Img5");
            if (input.FileImg6 is not null)
                stayDto.Img6 = await GetFilePath(input.FileImg6, "Stay", "Img6");
            if (input.FileImg7 is not null)
                stayDto.Img7 = await GetFilePath(input.FileImg7, "Stay", "Img7");
            if (input.FileImg8 is not null)
                stayDto.Img8 = await GetFilePath(input.FileImg8, "Stay", "Img8");
            if (input.FileImg9 is not null)
                stayDto.Img9 = await GetFilePath(input.FileImg9, "Stay", "Img9");
            if (input.FileImg10 is not null)
                stayDto.Img10 = await GetFilePath(input.FileImg10, "Stay", "Img10");

            var id = await _stayAppService.AddOrEditAsync(stayDto);
            if (id <= 0) throw new Exception("住宿发布失败");

            return Redirect("/Stay/Index");
        }

        public IActionResult StayList()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> DeleteStay([FromBody] int id)
        {
            return await _stayAppService.DeleteAsync(id);
        }

        #endregion

        #region 票券发布

        public async Task<IActionResult> AddTicket(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var ticket = await _ticketAppService.GetAsync(id.Value);
                var ticketView = Mapper.Map<TicketViewModel>(ticket);
                return View(ticketView);
            }
            return View(new TicketViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket([FromForm] TicketViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            var ticketDto = Mapper.Map<TicketDto>(input);
            if (input.FileImg1 is not null)
                ticketDto.Img1 = await GetFilePath(input.FileImg1, "Ticket", "Img1");
            if (input.FileImg2 is not null)
                ticketDto.Img2 = await GetFilePath(input.FileImg2, "Ticket", "Img2");
            if (input.FileImg3 is not null)
                ticketDto.Img3 = await GetFilePath(input.FileImg3, "Ticket", "Img3");
            if (input.FileImg4 is not null)
                ticketDto.Img4 = await GetFilePath(input.FileImg4, "Ticket", "Img4");
            if (input.FileImg5 is not null)
                ticketDto.Img5 = await GetFilePath(input.FileImg5, "Ticket", "Img5");
            if (input.FileImg6 is not null)
                ticketDto.Img6 = await GetFilePath(input.FileImg6, "Ticket", "Img6");
            if (input.FileImg7 is not null)
                ticketDto.Img7 = await GetFilePath(input.FileImg7, "Ticket", "Img7");
            if (input.FileImg8 is not null)
                ticketDto.Img8 = await GetFilePath(input.FileImg8, "Ticket", "Img8");
            if (input.FileImg9 is not null)
                ticketDto.Img9 = await GetFilePath(input.FileImg9, "Ticket", "Img9");
            if (input.FileImg10 is not null)
                ticketDto.Img10 = await GetFilePath(input.FileImg10, "Ticket", "Img10");

            var id = await _ticketAppService.AddOrEditAsync(ticketDto);
            if (id <= 0) throw new Exception("票券发布失败");

            return Redirect("/Ticket/Index");
        }

        public IActionResult TicketList()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> DeleteTicket([FromBody] int id)
        {
            return await _ticketAppService.DeleteAsync(id);
        }

        #endregion

        #region 美食发布

        public async Task<IActionResult> AddFood(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var food = await _foodAppService.GetAsync(id.Value);
                var foodView = Mapper.Map<FoodViewModel>(food);
                return View(foodView);
            }
            return View(new FoodViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddFood([FromForm] FoodViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            var foodDto = Mapper.Map<FoodDto>(input);
            if (input.FileImg1 is not null)
                foodDto.Img1 = await GetFilePath(input.FileImg1, "Food", "Img1");
            if (input.FileImg2 is not null)
                foodDto.Img2 = await GetFilePath(input.FileImg2, "Food", "Img2");
            if (input.FileImg3 is not null)
                foodDto.Img3 = await GetFilePath(input.FileImg3, "Food", "Img3");
            if (input.FileImg4 is not null)
                foodDto.Img4 = await GetFilePath(input.FileImg4, "Food", "Img4");
            if (input.FileImg5 is not null)
                foodDto.Img5 = await GetFilePath(input.FileImg5, "Food", "Img5");
            if (input.FileImg6 is not null)
                foodDto.Img6 = await GetFilePath(input.FileImg6, "Food", "Img6");
            if (input.FileImg7 is not null)
                foodDto.Img7 = await GetFilePath(input.FileImg7, "Food", "Img7");
            if (input.FileImg8 is not null)
                foodDto.Img8 = await GetFilePath(input.FileImg8, "Food", "Img8");
            if (input.FileImg9 is not null)
                foodDto.Img9 = await GetFilePath(input.FileImg9, "Food", "Img9");
            if (input.FileImg10 is not null)
                foodDto.Img10 = await GetFilePath(input.FileImg10, "Food", "Img10");

            var id = await _foodAppService.AddOrEditAsync(foodDto);
            if (id <= 0) throw new Exception("美食发布失败");

            return Redirect("/Food/Index");
        }

        public IActionResult FoodList()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> DeleteFood([FromBody] int id)
        {
            return await _foodAppService.DeleteAsync(id);
        }

        #endregion

        #region 接送发布

        public async Task<IActionResult> AddPickup(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var pickup = await _pickupAppService.GetAsync(id.Value);
                var pickupView = Mapper.Map<PickupViewModel>(pickup);
                return View(pickupView);
            }
            return View(new PickupViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddPickup([FromForm] PickupViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            var pickupDto = Mapper.Map<PickupDto>(input);
            if (input.FileImg1 is not null)
                pickupDto.Img1 = await GetFilePath(input.FileImg1, "Pickup", "Img1");
            if (input.FileImg2 is not null)
                pickupDto.Img2 = await GetFilePath(input.FileImg2, "Pickup", "Img2");
            if (input.FileImg3 is not null)
                pickupDto.Img3 = await GetFilePath(input.FileImg3, "Pickup", "Img3");
            if (input.FileImg4 is not null)
                pickupDto.Img4 = await GetFilePath(input.FileImg4, "Pickup", "Img4");
            if (input.FileImg5 is not null)
                pickupDto.Img5 = await GetFilePath(input.FileImg5, "Pickup", "Img5");
            if (input.FileImg6 is not null)
                pickupDto.Img6 = await GetFilePath(input.FileImg6, "Pickup", "Img6");
            if (input.FileImg7 is not null)
                pickupDto.Img7 = await GetFilePath(input.FileImg7, "Pickup", "Img7");
            if (input.FileImg8 is not null)
                pickupDto.Img8 = await GetFilePath(input.FileImg8, "Pickup", "Img8");
            if (input.FileImg9 is not null)
                pickupDto.Img9 = await GetFilePath(input.FileImg9, "Pickup", "Img9");
            if (input.FileImg10 is not null)
                pickupDto.Img10 = await GetFilePath(input.FileImg10, "Pickup", "Img10");

            var id = await _pickupAppService.AddOrEditAsync(pickupDto);
            if (id <= 0) throw new Exception("接送发布失败");

            return Redirect("/Pickup/Index");
        }

        public IActionResult PickupList()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> DeletePickup([FromBody] int id)
        {
            return await _pickupAppService.DeleteAsync(id);
        }

        #endregion

        #region 导游发布

        public async Task<IActionResult> AddGuide(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var guide = await _guideAppService.GetAsync(id.Value);
                var guideView = Mapper.Map<GuideViewModel>(guide);
                return View(guideView);
            }
            return View(new GuideViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide([FromForm] GuideViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            var guideDto = Mapper.Map<GuideDto>(input);
            if (input.FileImg1 is not null)
                guideDto.Img1 = await GetFilePath(input.FileImg1, "Guide", "Img1");
            if (input.FileImg2 is not null)
                guideDto.Img2 = await GetFilePath(input.FileImg2, "Guide", "Img2");
            if (input.FileImg3 is not null)
                guideDto.Img3 = await GetFilePath(input.FileImg3, "Guide", "Img3");
            if (input.FileImg4 is not null)
                guideDto.Img4 = await GetFilePath(input.FileImg4, "Guide", "Img4");
            if (input.FileImg5 is not null)
                guideDto.Img5 = await GetFilePath(input.FileImg5, "Guide", "Img5");
            if (input.FileImg6 is not null)
                guideDto.Img6 = await GetFilePath(input.FileImg6, "Guide", "Img6");
            if (input.FileImg7 is not null)
                guideDto.Img7 = await GetFilePath(input.FileImg7, "Guide", "Img7");
            if (input.FileImg8 is not null)
                guideDto.Img8 = await GetFilePath(input.FileImg8, "Guide", "Img8");
            if (input.FileImg9 is not null)
                guideDto.Img9 = await GetFilePath(input.FileImg9, "Guide", "Img9");
            if (input.FileImg10 is not null)
                guideDto.Img10 = await GetFilePath(input.FileImg10, "Guide", "Img10");

            var id = await _guideAppService.AddOrEditAsync(guideDto);
            if (id <= 0) throw new Exception("导游发布失败");

            return Redirect("/Guide/Index");
        }

        public IActionResult GuideList()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> DeleteGuide([FromBody] int id)
        {
            return await _guideAppService.DeleteAsync(id);
        }

        #endregion

        #region 娱乐发布

        public async Task<IActionResult> AddPlay(int? id)
        {
            if (id.HasValue && id.Value > 0)
            {
                var play = await _playAppService.GetAsync(id.Value);
                var playView = Mapper.Map<PlayViewModel>(play);
                return View(playView);
            }
            return View(new PlayViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddPlay([FromForm] PlayViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            var playDto = Mapper.Map<PlayDto>(input);
            if (input.FileImg1 is not null)
                playDto.Img1 = await GetFilePath(input.FileImg1, "Play", "Img1");
            if (input.FileImg2 is not null)
                playDto.Img2 = await GetFilePath(input.FileImg2, "Play", "Img2");
            if (input.FileImg3 is not null)
                playDto.Img3 = await GetFilePath(input.FileImg3, "Play", "Img3");
            if (input.FileImg4 is not null)
                playDto.Img4 = await GetFilePath(input.FileImg4, "Play", "Img4");
            if (input.FileImg5 is not null)
                playDto.Img5 = await GetFilePath(input.FileImg5, "Play", "Img5");
            if (input.FileImg6 is not null)
                playDto.Img6 = await GetFilePath(input.FileImg6, "Play", "Img6");
            if (input.FileImg7 is not null)
                playDto.Img7 = await GetFilePath(input.FileImg7, "Play", "Img7");
            if (input.FileImg8 is not null)
                playDto.Img8 = await GetFilePath(input.FileImg8, "Play", "Img8");
            if (input.FileImg9 is not null)
                playDto.Img9 = await GetFilePath(input.FileImg9, "Play", "Img9");
            if (input.FileImg10 is not null)
                playDto.Img10 = await GetFilePath(input.FileImg10, "Play", "Img10");

            var id = await _playAppService.AddOrEditAsync(playDto);
            if (id <= 0) throw new Exception("娱乐发布失败");

            return Redirect("/Play/Index");
        }

        public IActionResult PlayList()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> DeletePlay([FromBody] int id)
        {
            return await _playAppService.DeleteAsync(id);
        }

        #endregion

        #region 会员管理

        public IActionResult Member()
        {
            return View();
        }

        [HttpPost]
        public async Task<PagedResultDto<UserDto>> MemberList([FromBody] MemberPagedQueryDto input)
        {
            input.IsOff = false;
            return await _userAppService.GetListAsync(input);
        }

        public IActionResult MemberOff()
        {
            return View();
        }

        [HttpPost]
        public async Task<PagedResultDto<UserDto>> MemberOffList([FromBody] MemberPagedQueryDto input)
        {
            input.IsOff = true;
            return await _userAppService.GetListAsync(input);
        }

        [HttpPost]
        public async Task<bool> MemberAgree([FromBody] int id)
        {
            return await _userAppService.MemberAgree(id);
        }

        #endregion

        #region MyRegion

        public IActionResult Technician()
        {
            return View();
        }

        [HttpPost]
        public async Task<PagedResultDto<TechnicianDto>> TechnicianList([FromBody] TechnicianPagedQueryDto input)
        {
            return await _technicianAppService.GetListAsync(input);
        }

        public async Task<IActionResult> TechnicianFile(int id)
        {
            var technician = await _technicianAppService.GetAsync(id);
            if (string.IsNullOrEmpty(technician.WorkExperienceFilePath))
                throw new Exception("未找到文件数据");
            var path1 = Path.Combine(_environment.ContentRootPath, "wwwroot", technician.WorkExperienceFilePath);
            var path = Path.Combine(_environment.WebRootPath, technician.WorkExperienceFilePath);
            return File(path, "application/vnd.ms-excel");
        }

        #endregion

        public async Task<PagedResultDto<ItListInfoDto>> ItList([FromBody] ItListInfoPagedQueryDto input)
        {
            return await _itListInfoAppService.GetListAsync(input);
        }

        #region お問合せ管理

        public IActionResult CorporateList()
        {
            return View();
        }

        [HttpPost]
        public async Task<PagedResultDto<CorporateDto>> GetCorporateList([FromBody] CorporatePagedQueryDto input)
        {
            var dtos = await _corporateAppService.GetListAsync(input);
            return dtos;
        }

        [HttpPost]
        public async Task<bool> DeleteCorporate([FromBody] int id)
        {
            return await _corporateAppService.DeleteAsync(id);
        }

        #endregion


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
                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
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
