namespace ThAmCo.Events.ViewModels.EventViewModels;

public class CreateEventFormViewModel
{


    [Display(Name = "Event Name")]
    // we don't need this 'Required',  string to .net5 was nullable by defalut. But sinc .net6 string by defalut is Required (I sow you commented it out in project.cs you could have just changed the value to disable as well )
    [Required(ErrorMessage = "Please enter Event name.")]
    /// <summary>
    /// in this event model i demostrate couple of security protection
    /// I used Regular expression for validaiton 
    /// This Technique i know from a book i read its name was : ASP.NET Core 5 Secure Coding Cookbook By Roman Canlas, Ed Price · 2021#
    /// https://www.google.co.uk/books/edition/ASP_NET_Core_5_Secure_Coding_Cookbook/R-I3EAAAQBAJ?hl=en&gbpv=0
    /// 
    /// This will prevent any string injection, i might talk about it in the report! with an example.

    [RegularExpression(@"^[a-zA-Z0-9\s\-_',.()&]*$",
        ErrorMessage = "Invalid characters in the event name.")]     // Regular expression Validation to not insert silly characters check the validation here: https://regex101.com/
    
    ///  restricted the length to be between 3 and 25
    [StringLength(25, MinimumLength = 3,
        ErrorMessage = "Event's name length must be between 3 & 25 char.")]
    public string EventName { get; set; }= string.Empty;
    [Display(Name = "Event Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    [Required(ErrorMessage = "Please enter Event Date.")]
    [FutureDate(ErrorMessage = "Event Date must be in the future.")]
    public DateTime EventDate { get; set; } = DateTime.Now;

    public DateTime TomorrowDate = DateTime.Today.AddDays(1);
    public string EventTypeName { get; set; } = string.Empty;

    [Display(Name = "Event Type")]
    [Required(ErrorMessage = "Please chose Event Type.")]
    public string EventTypeId { get; set; } = string.Empty;
    [Display(Name = "Event Type")]
    public string ReservationId { get; set; } = string.Empty;

    public string FoodBookingId { get; set; } = string.Empty;
     public IEnumerable<SelectListItem> EventtypesFromApi { get; set; } = Enumerable.Empty<SelectListItem>();// Drop Down values
    public IEnumerable<SelectListItem> FoodBookings { get; set; } = Enumerable.Empty<SelectListItem>(); // Drop Down values
    public IEnumerable<SelectListItem> MenusForBooking { get; set; } = Enumerable.Empty<SelectListItem>(); // Drop Down values menus


    [Display(Name = "Choose a menu to book food")]
    public int? SelectedMenuId { get; set; }

   public string SelectedAvailability { get; set; } = string.Empty;

}
public class FutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value is DateTime inputDate)
        {
            var tomorrow = DateTime.Now;

            // Check if the inputDate is greater than or equal to tomorrow
            return inputDate >= tomorrow;
        }

        // Return false if the input is not a DateTime
        return false;
    }
}
