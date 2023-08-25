using FeedMe.Models.FoodHandler;
using Microsoft.AspNetCore.Mvc;

namespace FeedMe.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IfoodFunc _food;

        public ShoppingController(IfoodFunc ifood)
        {
            _food = ifood;
        }
        
        
        //for Users
        public IActionResult Shopping()
        {
            ViewBag.Food = _food.Count();
            return View();
        }


        //for developer
        public IActionResult ShowMeals()
        {
            return View(_food.GetFoods());
        }

        [HttpPost]
        public IActionResult DeleteMeal()
        {
            return RedirectToAction("Shopping", "Food Shopping");
        }

        #region Adding New Meal
        public IActionResult AddMeal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMeal(Food ifood)
        {
            _food.InsertNewMeal(ifood);
            
            return RedirectToAction("Shopping", "Food Shopping");
        }
        #endregion

        #region Update Meal
        public IActionResult UpdateMeal(int id)
        {
            return View(_food.GetMeal(id));
        }

        [HttpPost]
        public IActionResult UpdateMeal(Food ifood)
        {
            _food.UpdateMeal(ifood);
            return RedirectToAction("Shopping", "Food Shooping");
        }
        #endregion
    }
}
