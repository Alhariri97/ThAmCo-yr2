namespace ThAmCo.Events.ViewModels.EventViewModels;

public class DetailsEventFormViewModel
{
    public bool IsThereFirstAider
    {
        get
        {

            if (Staff != null && Staff.Any())
            {
                return !Staff.Any(staff => staff.FirstAider);
            }

            return true;
        }
    }

    public bool IsThereOneStaffPerTenGuests
    {
        get
        {
            int guestsCount = Guests.Count();
            int staffNeeded = (int)Math.Ceiling(guestsCount / 10.0);
            return Staff.Count() >= staffNeeded;
        }
    }

    public int EventId { get; set; }

    public string EventName { get; set; }
    [Display(Name = "Event Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EventDate { get; set; } = DateTime.Now;
    public string EventTypeName { get; set; } = string.Empty;

    [Display(Name = "Event Type")]
    public string EventTypeId { get; set; } = string.Empty;


    [Display(Name = "Event Type")]
    public string ReservationId { get; set; } = string.Empty;


    public string FoodBookingId { get; set; } = string.Empty;

    [Display(Name = "Staff")]
    public IEnumerable<StaffDTO> Staff { get; set; } = Enumerable.Empty<StaffDTO>();// Drop Down values

    [Display(Name = "Guests")]
    public IEnumerable<GuestDTO> Guests { get; set; } = Enumerable.Empty<GuestDTO>();// Drop Down values
    
    [Display(Name = "Food items")]
    public IEnumerable<FoodItemDTO> FoodItems { get; set; } = Enumerable.Empty<FoodItemDTO>(); // Drop Down values
}
