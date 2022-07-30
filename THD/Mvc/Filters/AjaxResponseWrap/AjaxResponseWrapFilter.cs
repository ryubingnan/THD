using THD.Web.Core.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace THD.Web.Mvc.Filters
{
    class AjaxResponseWrapFilter : IAsyncResultFilter
    {
        private readonly AjaxResponseWrapOptions _options;

        public AjaxResponseWrapFilter(IOptions<AjaxResponseWrapOptions> options)
        {
            _options = options.Value;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var wrapper = WrapAjaxResponse(objectResult.Value, context.HttpContext);
                objectResult.Value = wrapper.Value;
                objectResult.DeclaredType = wrapper.Value.GetType();

                if (wrapper.RewriteHttpStatusCode)
                {
                    objectResult.StatusCode = wrapper.HttpStatusCode;
                }
            }
            else if (context.Result is EmptyResult)
            {
                var wrapper = WrapAjaxResponse(null, context.HttpContext);

                var result = new ObjectResult(wrapper.Value);
                result.DeclaredType = wrapper.Value.GetType();

                context.Result = result;
            }

            await next();
        }

        private AjaxResponseWrapper WrapAjaxResponse(object currentValue, HttpContext httpContext)
        {
            if (currentValue is IAjaxResponse)
                return new AjaxResponseWrapper(currentValue);

            if (currentValue is ProblemDetails problemDetails)
            {
                if (!_options.WrapProblemDetails)
                    return new AjaxResponseWrapper(currentValue);

                var failedMsg = string.Empty;
                if (currentValue is ValidationProblemDetails validationProblemDetails)
                {
                    failedMsg = string.Join(string.Empty, validationProblemDetails.Errors.SelectMany(s => s.Value));
                }

                failedMsg = string.IsNullOrEmpty(failedMsg) ? problemDetails.Title : failedMsg;

                var rewriteHttpStatusCode = _options.ProblemDetailsResponseStatusCode.HasValue;
                var stautsCode = _options.ProblemDetailsResponseStatusCode ?? problemDetails.Status ?? httpContext.Response.StatusCode;

                return new AjaxResponseWrapper(AjaxResponse.Failed(problemDetails.Detail, failedMsg, stautsCode.ToString()), rewriteHttpStatusCode, stautsCode);
            }

            return new AjaxResponseWrapper(AjaxResponse.Succeed(currentValue));
        }

        public struct AjaxResponseWrapper
        {
            public object Value { get; set; }

            public bool RewriteHttpStatusCode { get; set; }

            public int? HttpStatusCode { get; set; }

            public AjaxResponseWrapper(object value, bool rewriteHttpStatusCode = false, int? httpStatusCode = null)
            {
                Value = value;
                RewriteHttpStatusCode = rewriteHttpStatusCode;
                HttpStatusCode = httpStatusCode;
            }
        }
    }
}
