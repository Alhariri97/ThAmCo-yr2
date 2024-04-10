namespace ThAmCo.Events.ViewModels.CateringViewModels;

public class DisplayFoodBookingDetailsViewModel : FoodBookingViewModel
{
    public MenuDTO Menu { get; set; } = new MenuDTO();

    public DisplayFoodBookingDetailsViewModel(IEventService eventService, FoodBookingDTO food) : base(eventService, food)
    {
    }
}
