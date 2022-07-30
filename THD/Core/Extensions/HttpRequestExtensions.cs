using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;

namespace THD.Web.Core.Extensions
{
    public static class HttpRequestExtensions
    {
        public static bool AcceptJson(this HttpRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return request.Headers[HeaderNames.Accept].Any(type => type.Contains("json"));
        }
    }
}
