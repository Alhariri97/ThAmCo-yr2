namespace ThAmCo.Events.DTO
{
    public class FoodItemDTO
    {
        public string Name { get; set; }
        public int  FoodItemId { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
    }
    public class PostFoodItemDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
    }
}
