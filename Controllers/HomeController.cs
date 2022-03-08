using CoreAndFood.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("Home/ReturnViewWithSelectedFoods/{selectedCategoryID:int}")]
        public IActionResult ReturnViewWithSelectedFoods(int selectedCategoryID)
        {
            ViewBag.selectedFoods = ReturnListOfFood(selectedCategoryID);
            return View("Index");
        }

        public List<Food> ReturnListOfFood(int selectedCategoryID)
        {
            FoodRepository foodRepositories = new();
            List<Food> allFoods = foodRepositories.ListItem("Category");
            List<Food> filteredCategories = new();
            for (int i = 0; i < allFoods.Count; i++)
            {
                if (allFoods[i].Category.CategoryID == selectedCategoryID)
                {
                    filteredCategories.Add(allFoods[i]);
                }
            }
            return filteredCategories;
        }
    }
}
