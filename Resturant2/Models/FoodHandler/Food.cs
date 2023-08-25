namespace FeedMe.Models.FoodHandler
{
    public class Food
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
    }
}
