using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ThuyTien.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        [Route("/authenticate")]
        public async Task<IActionResult> Authenticate([FromQuery] string user, [FromQuery] string pwd)
        {
            if (user == "thuytien" && pwd == "adminadmin")
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user),
                    new Claim(ClaimTypes.Email, "tientran1882003@gmail.com"),
                    new Claim(ClaimTypes.HomePhone,"0358791873")
                };
                var userIdentity = new ClaimsIdentity(userClaims, "ThuyTien.CookieAuth");
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync("ThuyTien.CookieAuth", userPrincipal);

            }
            return Redirect("/outstandingorders");
        }
        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/outstandingorders");
        }
    }
}
