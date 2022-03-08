using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class Kendo : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
