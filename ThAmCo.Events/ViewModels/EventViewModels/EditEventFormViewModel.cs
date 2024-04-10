namespace ThAmCo.Events.ViewModels.EventViewModels;

public class EditEventFormViewModel
{
    public int EventId { get; set; }

    [Display(Name = "Event Name")]
    [Required(ErrorMessage = "Please enter Event name.")]
    public string EventName { get; set; }
    [Display(Name = "Event Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EventDate { get; set; }


    public DateTime TomorrowDate = DateTime.Today.AddDays(1);
    [Display(Name = "Event Type")]
    public string EventTypeName { get; set; } = string.Empty;

    [Display(Name = "Event Type")]
    [Required(ErrorMessage = "Please chose Event Type.")]
    public string EventTypeId { get; set; } = string.Empty;
    [Display(Name = "Event Type")]
    public string ReservationId { get; set; } = string.Empty;

    public string FoodBookingId { get; set; } = string.Empty;
    public IEnumerable<SelectListItem> Staffs { get; set; } = Enumerable.Empty<SelectListItem>();// Drop Down values
    public IEnumerable<SelectListItem> Guests { get; set; } = Enumerable.Empty<SelectListItem>();// Drop Down values
    public IEnumerable<SelectListItem> AvailableVenus { get; set; } = Enumerable.Empty<SelectListItem>();// Drop Down values
    public IEnumerable<SelectListItem> FoodBookings { get; set; } = Enumerable.Empty<SelectListItem>(); // Drop Down values
    public IEnumerable<SelectListItem> MenusForBooking { get; set; } = Enumerable.Empty<SelectListItem>(); // Drop Down values menus


    [Display(Name = "Venu Booked")]

    public ReservationDTO Reservation { get; set; }


    [Display(Name = "Choose a menu to make a food booking ")]
    public int? SelectedMenuId { get; set; }

    [Display(Name = "Asign staff")]
    public List<int> SelectedStaffs { get; set; } = new List<int>(); // Gonna be for the selected Staff

    [Display(Name = "Invite Guests")]
    public List<int> SelectedGuests { get; set; } = new List<int>(); // Gonna be for the selected Guests
    public string SelectedAvailability { get; set; }

    public FoodBookingDTO FoodBooking { get; set; } = null;
    public MenuDTO Menu { get; set; } = null;
    public IEnumerable<SelectListItem> AllMenus { get; set; } = null;
}


//"code": "CRKHL",
//        "name": "Crackling Hall",
//        "description": "Once the residence of Lord and Lady Crackling, this lavish dwelling remains a prime example of 18th century fine living.",
//        "capacity": 150,
//        "date": "2024-01-14T00:00:00",
//        "costPerHour": 64.03