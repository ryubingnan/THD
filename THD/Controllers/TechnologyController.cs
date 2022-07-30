using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THD.Web.Controllers.Abstract;

namespace THD.Web.Controllers
{
    public class TechnologyController : MvcControllerBase<HomeController>
    {

        public TechnologyController(ILogger<HomeController> logger, IMapper mapper)
            : base(logger, mapper)
        {

        }
        [AllowAnonymous]
        public IActionResult index()
        {
            return View();
        }
    }
}
