using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp 
{
    public class HttpContextCookieProvider : Controller, IAuthCookieProvider
    {
        protected HttpContext httpContext { get; set; }

        public HttpContextCookieProvider(HttpContext HttpContext)
        {
            httpContext = HttpContext;
        }

        public string GetCookie(string cookieKey)
        {
            return httpContext.Request.Cookies[cookieKey];
        }

        public void SetCookie(string cookieKey, string cookieValue)
        {
             httpContext.Response.Cookies.Append(cookieKey, cookieValue);
        }
    }
}
