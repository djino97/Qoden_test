using Microsoft.AspNetCore.Http;

namespace WebApp
{
    interface IAuthCookieProvider
    {
        string GetCookie(string cookieKey);

        void SetCookie(string cookieKey, string cookieValue);
    }
}
