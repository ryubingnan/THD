using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Linq;
using System.Security.Claims;

namespace THD.Web.Controllers.Abstract
{
    [Authorize]
    public abstract class MvcControllerBase<TController> : Controller
        where TController : class
    {
        protected ILogger<TController> Logger { get; }

        protected IMapper Mapper { get; }

        protected string UserId
        {
            get
            {
                return User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            }
        }
        protected string UserEmail
        {
            get
            {
                return User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            }
        }

        public MvcControllerBase(ILogger<TController> logger, IMapper mapper)
        {
            Logger = logger;
            Mapper = mapper;
        }
    }
}
