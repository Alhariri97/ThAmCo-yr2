namespace ThAmCo.Catering.DTOs;

public class MenuItemDTO
{
    public int MenuId { get; set; }
    public string MenuName { get; set; }
}
public class MenuDTO
{
    public string MenuName { get; set; }
}

public class MenuFoodItemDTO
{
    public int MenuId { get; set; }
    public string MenuName { get; set; }
    public List<FoodItemDTO> FoodItems { get; set; }
    static public MenuFoodItemDTO BuildDTO(Menu menu)
    {
        List<FoodItemDTO> foodItems = new ();
        MenuFoodItemDTO dto = new ();
        foodItems = menu.MenuFoodItems.Select(f => new FoodItemDTO
        {
            FoodItemId = f.FoodItemId,
            Name = f.FoodItem.Name,
            Description = f.FoodItem.Description,
            UnitPrice = f.FoodItem.UnitPrice
        }).ToList();
        dto.MenuId = menu.MenuId;
        dto.MenuName = menu.MenuName;
        dto.FoodItems = foodItems;
        return dto;
    }
}

public class MenuFoodBookingDTO
{
    public int MenuId { get; set; }
    public string MenuName { get; set; }
    public List<FoodBookingDTO> FoodBookings { get; set; }
}

public class MenuFoodItemEditModelDTO
{
    public int MenuId { get; set; }
    public List<int> FoodItems { get; set; }
}
