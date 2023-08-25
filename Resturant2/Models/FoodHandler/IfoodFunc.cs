namespace FeedMe.Models.FoodHandler
{
    public interface IfoodFunc
    {
        public List<Food> GetFoods();

        public void InsertNewMeal(Food newMeal);

        public void UpdateMeal(Food newMeal);

        public void DeleteMeal(int id);

        public Food GetMeal(int id);

        public int Count();
    }
}
