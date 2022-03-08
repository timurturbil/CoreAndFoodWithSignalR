using CoreAndFood.Models;
using EO.WebBrowser.DOM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreAndFood.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            if (string.IsNullOrEmpty(user.UserName) && string.IsNullOrEmpty(user.UserPassword)) return RedirectToAction("Login");

            var datavalue = c.Users.FirstOrDefault(x => x.UserName == user.UserName && x.UserPassword == user.UserPassword);

            if (datavalue == null) return View("Error");

            ClaimsIdentity identity = null;

            identity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, datavalue.UserName!),
                new Claim(ClaimTypes.Role, datavalue.UserRole!)
                }, "Login");

            ClaimsPrincipal principal = new(identity);

            await HttpContext.SignInAsync(principal);
            if (datavalue.UserRole == "user")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Category");
            }

        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        //public string GetCookie(string key)
        //{
        //    return Request.Cookies[key];
        //} 
        //public void SetCookie(string key, string value, int? expireTime)
        //{
        //    CookieOptions option = new CookieOptions();
        //    if (expireTime.HasValue)
        //        option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
        //    else
        //        option.Expires = DateTime.Now.AddMilliseconds(10);
        //    Response.Cookies.Append(key, value, option);
        //}
        //public void RemoveCookie(string key)
        //{
        //    Response.Cookies.Delete(key);
        //}
    }
}
