using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atomicf1.web
{
    public static class HttpRequestExtensions
    {
        public static string GetBaseUrl(this HttpRequest request)
        {
            return request.Url.GetLeftPart(UriPartial.Authority);
        }
    }
}