using ThAmCo.Events.Models;

namespace ThAmCo.Events.DTO;

public class AddToEventViewModel
{
    public List<Event> Events { get; set; }
    public Staff Staff { get; set; }
}
