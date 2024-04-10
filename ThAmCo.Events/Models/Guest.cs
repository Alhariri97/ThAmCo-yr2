namespace ThAmCo.Events.Models;

public class Guest  
{
    public int GuestId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}"; 
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<GuestBooking> GuestBookings { get; set; } = new List<GuestBooking>();
}
