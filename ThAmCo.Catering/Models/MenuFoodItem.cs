namespace ThAmCo.Catering.Models;
/// <summary>
///  Linking(bridg) table for FoodItme and Menu tables.
/// </summary>
public class MenuFoodItem
{
    [Required]
    public int MenuId { get; set; } // Composite Primary Key
    // Navigation properties
    public Menu Menu { get; set; }
    [Required]
    public int FoodItemId { get; set; } // Composite Primary Key
    // Navigation properties
    public FoodItem FoodItem { get; set; }
}

/// <summary>
/// We could have created the many to many relationship in easier where we don't have to create the joining table,
/// or in fact it will be created but EF will take care of that :)
/// way see: https://learn.microsoft.com/en-us/ef/core/modeling/relationships/many-to-many#:~:text=many%2Dto%2Dmany%20relationship%20can%20be%20mapped%20in%20this%20way 
/// I was gonna go that way but did not want to lose marks...
/// </summary>