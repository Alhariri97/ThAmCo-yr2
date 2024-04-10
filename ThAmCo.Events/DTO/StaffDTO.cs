using ThAmCo.Events.Models;

namespace ThAmCo.Events.DTO
{
    public class StaffDTO
    {
        // Parameterless constructor
        public StaffDTO()
        {
        }
        public StaffDTO(Staff staff)
        {
            StaffId = staff.StaffId;
            FirstName = staff.FirstName;
            LastName = staff.LastName;
            HieraData = staff.HieraData;
            FirstAider = staff.FirstAider;
            PhoneNumber = staff.PhoneNumber;
            Position = staff.Position;
        }
        public int StaffId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }
        public DateTime? HieraData { get; set; }
        public bool FirstAider { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter Staff's position.")]
        public string Position { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";


    }
}
