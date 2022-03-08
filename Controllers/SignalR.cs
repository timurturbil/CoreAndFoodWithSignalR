using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class SignalR : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
