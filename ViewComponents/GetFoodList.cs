using CoreAndFood.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
    public class GetFoodList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<Food> selectedFoods = ViewBag.selectedFoods;
            FoodRepository foodRepository = new();
            List<Food>? foodList;
            if (selectedFoods == null)
            {
                foodList = foodRepository.ListItem();
            }
            else
            {
                foodList = selectedFoods;
            }

            return View(foodList);


        }
    }
}
