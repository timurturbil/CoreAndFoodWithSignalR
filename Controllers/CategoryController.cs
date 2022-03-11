using CoreAndFood.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    [Authorize(Roles = "admin1, admin2, admin3")]
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepositories = new CategoryRepository();

        public IActionResult Index()
        {
            List<Category> filteredCategoryList = GetActiveCategories();
            return View(filteredCategoryList);

        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            try
            {
                Category category1 = new Category();
                category1.CategoryName = category.CategoryName;
                category1.CategoryDescription = category.CategoryDescription;
                category1.Status = true;
                categoryRepositories.AddItem(category1);
                return Json(new
                {
                    redirectUrl = Url.Action("Index", "Category"),
                    isRedirect = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = ex,
                    isRedirect = false
                });
            }
        }

        [Authorize(Roles = "admin1")]
        public IActionResult UpdateCategoryStatus(int id)
        {
            Category selectedCategory = categoryRepositories.GetItem(id);
            selectedCategory.Status = false;
            categoryRepositories.UpdateItem(selectedCategory);
            return RedirectToAction("Index");
        }

        public IActionResult GetCategory(int id)
        {
            Category category = categoryRepositories.GetItem(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            Category selectedCategory = categoryRepositories.GetItem(category.CategoryID);
            selectedCategory.CategoryName = category.CategoryName;
            selectedCategory.CategoryDescription = category.CategoryDescription;
            selectedCategory.Status = true;
            categoryRepositories.UpdateItem(selectedCategory);
            return RedirectToAction("Index");
        }

        static public List<Category> GetActiveCategories()
        {
            CategoryRepository categoryRepositories = new CategoryRepository();
            List<Category> filteredCategoryList = new List<Category>();
            List<Category> categoryList = categoryRepositories.ListItem();
            for (int i = 0; i < categoryList.Count; i++)
            {
                if (categoryList[i].Status)
                {
                    filteredCategoryList.Add(categoryList[i]);
                }

            }
            return filteredCategoryList;
        }

        public IActionResult ErrorView()
        {
            return View("ErrorView");
        }
    }
}
