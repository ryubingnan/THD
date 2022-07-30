using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THD.Service.Dtos;
using THD.Service.Interfaces;
using THD.Web.Controllers.Abstract;

namespace THD.Web.Controllers
{
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    public class CorporateController : MvcControllerBase<CorporateController>
    {
        private readonly ICorporateAppService _corporateAppService;

        public CorporateController(
            ILogger<CorporateController> logger,
            IMapper mapper,
            ICorporateAppService corporateAppService)
            : base(logger, mapper)
        {
            _corporateAppService = corporateAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult outline()
        {
            return View();
        }

        public IActionResult service()
        {
            return View();
        }
        
        public IActionResult news()
        {
            return View();
        }
        
        public IActionResult recruiting()
        {
            return View();
        }

        public IActionResult contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> AddCorporate([FromBody] CorporateDto input)
        {
            var id = await _corporateAppService.AddOrEditAsync(input);
            if (id <= 0) throw new Exception("案件发布失败");
            return true;
        }

        public IActionResult confirm()
        {
            return View();
        }
    }
}
