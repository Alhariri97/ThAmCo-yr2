namespace ThAmCo.Events.DTO;

public class GuestDTO
{
    public GuestDTO() { }
    public GuestDTO(Guest guest)
    {
        GuestId = guest.GuestId;
        FirstName = guest.FirstName;
        LastName = guest.LastName;
        Email = guest.Email;
        Phone = guest.Phone;
    }
    public int GuestId { get; set; }

    [Required(ErrorMessage = "Please enter a first name.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please enter a last name.")]
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string FullName => $"{FirstName} {LastName}";

}
