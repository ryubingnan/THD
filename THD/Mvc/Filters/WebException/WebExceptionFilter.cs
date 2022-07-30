using THD.Web.Core.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp;

namespace THD.Web.Mvc.Filters
{
    internal class WebExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<WebExceptionFilter> _logger;
        private readonly IWebHostEnvironment _env;

        public WebExceptionFilter(ILogger<WebExceptionFilter> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            if (!context.HttpContext.Request.AcceptJson())
            {
                return Task.CompletedTask;
            }

            if (!context.ExceptionHandled)
            {
                var currentException = context.Exception;
                var httpContext = context.HttpContext;

                if (currentException is UserFriendlyException userFriendlyException)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status200OK;
                    context.Result = new ObjectResult(AjaxResponse.Failed(
                        context.Result,
                        userFriendlyException.Message,
                        userFriendlyException.Code));
                }
                else
                {
                    var error = string.Empty;
                    if (_env.IsDevelopment())
                    {
                        error = currentException.ToString();
                    }
                    else
                    {
                        error = "服务器异常，请稍候重试";
                    }
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Result = new ObjectResult(AjaxResponse.Failed(error, httpContext.Response.StatusCode.ToString()));

                    _logger.LogError(currentException.ToString());
                }

                context.ExceptionHandled = true;
            }

            return Task.CompletedTask;
        }
    }
}
