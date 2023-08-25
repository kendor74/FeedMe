using Resturant2.Models;

namespace FeedMe.Models.FoodHandler
{
    public class FoodHelper : IfoodFunc
    {
        ResturantDbContext _context;

        public FoodHelper(ResturantDbContext context)
        {
            _context = context;
        }

        public void DeleteMeal(int id)
        {
            _context.Menus.Remove(_context.Menus.Find(id));
        }

        public List<Food> GetFoods()
        {
            return _context.Menus.ToList();
        }

        public Food GetMeal(int id)
        {
            return _context.Menus.Find(id);
        }

        public void InsertNewMeal(Food newMeal)
        {
            _context.Menus.Add(newMeal);
        }

        public void UpdateMeal(Food newMeal)
        {
            _context.Menus.Update(newMeal);
        }
    
        public int Count()
        {
            return _context.Menus.Count();
        }
    }
}
