namespace ThAmCo.Catering.Models;

public class Menu
{
    // Primary Key, did not need to use [Key] as it already has Id in it, Id or EnitityNameId
    public int MenuId { get; set; }
    [Required]
    [MaxLength(50)]
    public string MenuName { get; set; }

    //Many to Many with FoodItem using MenuFoodItem as a linking table
    public List<MenuFoodItem> MenuFoodItems { get; set; } = new List<MenuFoodItem>();

    public List<FoodBooking> FoodBookings { get; set; } = new List<FoodBooking>();
}
