namespace ThAmCo.Catering.Models;

public class FoodBooking
{
    public int FoodBookingId { get; set; } // Primary Key
    public int? ClientReferenceId { get; set; }
    public int NumberOfGuests { get; set; }
    public int MenuId { get; set; } // Foreign Key
    public DateTime FoodBookingDate { get; set; }

    // Navigation property to represent the relationship
    public Menu Menu { get; set; }
}
