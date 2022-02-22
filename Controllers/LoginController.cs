using CoreAndFood.Models;
using EO.WebBrowser.DOM;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoreAndFood.Controllers
{
    public class LoginController : Controller
    {

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(AdminModel admin)
        {
            Context c = new Context();

            var datavalue = c.Admins.FirstOrDefault(x=>x.AdminName == admin.AdminName && x.AdminPassword == admin.AdminPassword);
            if (datavalue == null) return View("Error");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.AdminName!)
            };
            var userIdentity = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
            HttpContext.Session.SetString("adminRole", datavalue.AdminRole);
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
