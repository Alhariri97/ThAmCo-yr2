namespace ThAmCo.Catering.Models;

public class FoodItem
{
    public int FoodItemId { get; set; }

    [Required]
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    [Required]
    public float UnitPrice { get; set; } 
    //Many to Many with Menu using MenuFoodItem as a linking table
    public List<MenuFoodItem> MenuFoodItems { get; set; }
}
