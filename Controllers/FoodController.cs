using CoreAndFood.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    [Authorize(Roles = "admin1, admin2")]
    public class FoodController : Controller
    {
        FoodRepository foodRepositories = new FoodRepository();
        CategoryRepository categoryRepositories = new CategoryRepository();
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {
            
            return View(foodRepositories.ListItem("Category").ToPagedList(page, 3));
        }

        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in categoryRepositories.ListItem()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),
                                           }).ToList();
            ViewBag.Values = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(Food food)
        {
            foodRepositories.AddItem(food);
            return Json(new { redirectUrl = Url.Action("Index", "Food") });
        }

        public IActionResult DeleteFood(int id)
        {
            Food selectedFood = foodRepositories.GetItem(id);
            foodRepositories.DeleteItem(selectedFood);
            return RedirectToAction("Index");
        }
    }
}
