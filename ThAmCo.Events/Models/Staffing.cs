namespace ThAmCo.Events.Models;

public class Staffing
{
    public int? StaffId { get; set; }
    public Staff Staff { get; set; } = default!;
    public int? EventId { get; set; }
    public Event Event { get; set; } = default!;

}
