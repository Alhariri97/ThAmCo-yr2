namespace ThAmCo.Events.Models;
public class Event 
{

    /// </summary>
    public int EventId { get; set; }
    [Required]
    public string EventName { get; set; } = string.Empty;
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EventDate { get; set; }
    public string EventTypeName { get; set; } = string.Empty;
    public List<Staffing> Staffings { get; set; } = new List<Staffing>();
    public List<GuestBooking> GuestBookings { get; set; } = new List<GuestBooking>();
    [Required]
    public string EventTypeId { get; set; } = string.Empty;
    public string ReservationId { get; set; } = string.Empty;
    public string FoodBookingId { get; set; } = string.Empty;
    public bool IsCanceled { get; set; } = false;
}
