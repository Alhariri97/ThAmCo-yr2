namespace ThAmCo.Events.ViewModels.CateringViewModels;

public class FoodBookingViewModel : FoodBookingDTO
{
    private readonly IEventService _eventService;
    public Event Event { get; set; }

    public FoodBookingViewModel(IEventService eventService, FoodBookingDTO food)
    {
        _eventService = eventService;

        FoodBookingDate = food.FoodBookingDate;
        FoodBookingId = food.FoodBookingId;
        ClientReferenceId = food.ClientReferenceId;
        NumberOfGuests = food.NumberOfGuests;
        MenuId = food.MenuId;

        if (food.ClientReferenceId != null)
        {
            this.Event = _eventService.GetSimpleEvent((int)food.ClientReferenceId);
        }
    }
}
