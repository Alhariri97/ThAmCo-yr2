namespace ThAmCo.Events.Models;

public class GuestBooking 
{
    public Guest Guest { get; set; } = default!;
    public int? GuestId { get; set; }
    public Event Event { get; set; } = default!;
    public int? EventId { get; set; }
}
