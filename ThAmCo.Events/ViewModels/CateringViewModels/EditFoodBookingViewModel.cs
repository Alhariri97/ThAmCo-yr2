namespace ThAmCo.Events.ViewModels.CateringViewModels;

public class EditFoodBookingViewModel
{
    public EditFoodBookingViewModel()
    {
    }
    public int FoodBookingId { get; set; }
    [Display(Name = "Event")]

    public int? ClientReferenceId { get; set; }
    [Display(Name = "Number of guests")]
    public int NumberOfGuests { get; set; }

    [Display(Name = "Cuurent Menu")]
    public int MenuId { get; set; } //current menu
    public MenuDTO Menu { get; set; }

    public Event Event { get; set; }

    [Display(Name = "Food Booking Date")]
    public DateTime FoodBookingDate { get; set; }
    public IEnumerable<SelectListItem> MenusAvailable { get; set; } = Enumerable.Empty<SelectListItem>(); // Drop Down values for menu to choes one 

    public IEnumerable<SelectListItem> EventWithouBooking { get; set; } = Enumerable.Empty<SelectListItem>(); // Drop Down values for menu to choes one 

    public EditFoodBookingViewModel( FoodBookingDTO booking)
    {
        FoodBookingId = booking.FoodBookingId;
        ClientReferenceId = booking.ClientReferenceId;
        NumberOfGuests = booking.NumberOfGuests;
        MenuId = booking.MenuId;
        FoodBookingDate = booking.FoodBookingDate;
    }
}
