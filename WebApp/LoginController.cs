using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApp
{
    [Route("api")]
    public class LoginController : Controller
    {
        private readonly IAccountDatabase _db;

       

        public LoginController(IAccountDatabase db)
        {
            _db = db;
        }

        [HttpPost("sign-in")]
        public async Task Login([FromBody] UserName userName)
        {
            
            var account = await _db.FindByUserNameAsync(userName.userName);

           
            if (account != null)
            {
                //TODO 1: Generate auth cookie for user 'userName' with external id
                HttpContext.User.AddIdentity(new ClaimsIdentity("userNa", userName.userName, account.Role));
                
                HttpContextCookieProvider HttpCookie = new HttpContextCookieProvider(HttpContext);
                HttpCookie.SetCookie(account.UserName, account.ExternalId);
            }

            //TODO 2: return 404 if user not found
            else
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
            }   
        }
    }
}