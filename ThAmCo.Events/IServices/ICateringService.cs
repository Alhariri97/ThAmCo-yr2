namespace ThAmCo.Events.IServices;


/// <summary>
/// This service concets to the Catering projects.
/// To call the end points provided by Catering 
/// </summary>
public interface ICateringService
{
    /// <summary>
    /// Returns all Food Bookings
    /// </summary>
    /// <returns></returns>
    public Task<List<FoodBookingDTO>> GetAllFoodBookings();
    /// <summary>
    /// Create a food Booking
    /// </summary>
    /// <param name="foodBookingDTO"></param>
    /// <returns></returns>
    public Task<int?> CreateFoodBooking(FoodBookingDTO foodBookingDTO);
    /// <summary>
    /// Get a foodBooking by its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<FoodBookingDTO> GetFoodBooking(int id);

    /// <summary>
    /// Delete a food Booking
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteFoodBooking(int id);
    /// <summary>
    /// Cancel a food Booking
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> CancelFoodBooking(int id);
    /// <summary>
    /// Update a food booking
    /// </summary>
    /// <param name="id"></param>
    /// <param name="foodBookingDTO"></param>
    /// <returns></returns>
    public Task<bool> EditFoodBooking( int id, FoodBookingDTO foodBookingDTO);


    /// The comments above for food booking i beleive they are silly 
    /// no point of writing them since the method's name tells what it is about!
    /// I'm not writing for the others!

    /// <summary>
    /// Calls for Menus
    /// </summary>
    /// <returns></returns>
    public Task<List<MenuDTO>> GetAllMenus();
    public Task<bool> CreateMenu(string menuName);
    public Task<MenuDTO> GetMenuWithFoodItems(int id);
    public Task<bool> EditMenu(int id, string newName);
    public Task<bool> EditFoodItemsInMenu(int id, int[] foodItemIdsList);
    public Task<bool> DeleteMenu(int id);


    /// <summary>
    /// Calls for Fooditems
    /// </summary>
    /// <returns></returns>

    public Task<List<FoodItemDTO>> GetAllFoodItems();
    public Task<bool> CreateFoodItem(PostFoodItemDTO foodItemDTO);
    public Task<FoodItemDTO> GetFoodItem(int id);
    public Task<bool> EditFoodItem(int id, FoodItemDTO foodItemDTO);
    public Task<bool> DeleteFoodItem(int id);

}
