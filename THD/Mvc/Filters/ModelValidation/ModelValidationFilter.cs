using THD.Web.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace THD.Web.Mvc.Filters
{
    public class ModelValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                if (context.HttpContext.Request.AcceptJson())
                {
                    var errorMsg = string.Join(Environment.NewLine, context.ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));
                    context.Result = new ObjectResult(AjaxResponse.Failed(errorMsg));
                }
                else
                {
                    context.Result = new ViewResult();
                }

                return;
            }

            await next();
        }
    }
}
