namespace ThAmCo.Events.DTO
{
    public class MenuDTO
    {
        public int  MenuId { get; set; }
        public string MenuName { get; set; }
        public List<FoodItemDTO> FoodItems { get; set; }
    }
}
