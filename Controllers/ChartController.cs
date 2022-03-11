using CoreAndFood.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CoreAndFood.Controllers.CategoryController;

namespace CoreAndFood.Controllers
{
    [Authorize(Roles = "admin1, admin2, admin3")]
    public class ChartController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }

        public List<ChartModel> ProList()
        {
            List<ChartModel> cs = new List<ChartModel>();
            FoodRepository foodRepositories = new FoodRepository();
            List<Food> allFoods = foodRepositories.ListItem();
            cs = allFoods.Select(food => new ChartModel
            {
                name = food.Name,
                stock = food.Stock,
            }).ToList();
            return cs;
        }

        public IActionResult Statistics()
        {
            ViewBag.totalFood = c.Foods.Count();
            ViewBag.totalCategory = GetActiveCategories().Count;
            ViewBag.FruitCount = CategoryCount("Meyve");
            ViewBag.Vegetables = CategoryCount("Sebze");
            ViewBag.Legumes = CategoryCount("Baklagil");
            ViewBag.totalStock = c.Foods.Sum(food => food.Stock);
            ViewBag.MaxStockFood = c.Foods.OrderByDescending(food => food.Stock).Select(x => x.Name).FirstOrDefault();
            ViewBag.MinStockFood = c.Foods.OrderByDescending(food => food.Stock).Select(x => x.Name).LastOrDefault();
            return View();
        }

        public int CategoryCount(string selectedCategoryName)
        {
            FoodRepository foodRepositories = new FoodRepository();
            List<Food> allFoods = foodRepositories.ListItem("Category");
            List<Food> filteredCategories = new List<Food>();
            for (int i = 0; i < allFoods.Count; i++)
            {
                if (allFoods[i].Category.CategoryName == selectedCategoryName)
                {
                    filteredCategories.Add(allFoods[i]);
                }
            }
            return filteredCategories.Count;
        }

        public Dictionary<string, dynamic> GetStatisticsData()
        {
            Dictionary<string, dynamic> myDictionary = new Dictionary<string, dynamic>();
            var totalFood = c.Foods.Count();
            var totalCategory = GetActiveCategories().Count;
            var FruitCount = CategoryCount("Meyve");
            var Vegetables = CategoryCount("Sebze");
            var Legumes = CategoryCount("Baklagil");
            var totalStock = c.Foods.Sum(food => food.Stock);
            var MaxStockFood = c.Foods.OrderByDescending(food => food.Stock).Select(x => x.Name).FirstOrDefault();
            var MinStockFood = c.Foods.OrderByDescending(food => food.Stock).Select(x => x.Name).LastOrDefault();
            myDictionary.Add("totalFood", totalFood);
            myDictionary.Add("totalCategory", totalCategory);
            myDictionary.Add("FruitCount", FruitCount);
            myDictionary.Add("Vegetables", Vegetables);
            myDictionary.Add("Legumes", Legumes);
            myDictionary.Add("totalStock", totalStock);
            myDictionary.Add("MaxStockFood", MaxStockFood);
            myDictionary.Add("MinStockFood", MinStockFood);
            return myDictionary;
        }
    }
}
