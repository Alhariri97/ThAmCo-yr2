namespace ThAmCo.Events.Models;

public class Staff 
{
    public int StaffId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? HieraData { get; set; } = DateTime.Now.Date;
    public bool FirstAider { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;

    // Navigation property for one-to-many relationship
    public List<Staffing> Staffings { get; set; } = new List<Staffing>();
}
