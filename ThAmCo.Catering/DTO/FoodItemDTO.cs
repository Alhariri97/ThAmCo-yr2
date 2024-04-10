namespace ThAmCo.Catering.DTOs;

public class FoodItemDTO
{
    public FoodItemDTO CreateFoodItemDTO(FoodItem foodItem)
    {
        return new FoodItemDTO {
            Description = foodItem.Description,
            Name = foodItem.Name,
            UnitPrice = foodItem.UnitPrice,
            FoodItemId = foodItem.FoodItemId,
        };
    }
    public int FoodItemId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float UnitPrice { get; set; }
}
public class FoodItemCreateDTO
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; } = null!;
    [Required]
    public float UnitPrice { get; set; }
}