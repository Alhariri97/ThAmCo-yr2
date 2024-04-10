namespace ThAmCo.Events.ViewModels.EventViewModels;
public class DisplayEventsFromViewModel : Event
{
    public bool IsThereFirstAider
    {
        get
        {
            // Check if there are any guests before checking for a first aider
            if (GuestBookings.Any())
            {
                return Staffings.Any(staffing => staffing.Staff?.FirstAider == true); ;
            }
            return true;
        }
    }

    public bool IsThereOneStaffPerTenGuests
    {
        get
        {
            int guestsCount = GuestBookings.Count;
            int staffNeeded = (int)Math.Ceiling(guestsCount / 10.0);
            return Staffings.Count >= staffNeeded;
        }
    }

    // Static method to convert Event to DisplayEventsFromViewModel
    public static DisplayEventsFromViewModel FromEvent(Event eventModel)
    {
        return new DisplayEventsFromViewModel
        {
            EventId = eventModel.EventId,
            EventName = eventModel.EventName,
            EventDate = eventModel.EventDate,
            EventTypeName = eventModel.EventTypeName,
            Staffings = eventModel.Staffings,
            GuestBookings = eventModel.GuestBookings,
            EventTypeId = eventModel.EventTypeId,
            ReservationId = eventModel.ReservationId,
            FoodBookingId = eventModel.FoodBookingId,
            IsCanceled = eventModel.IsCanceled,
        };
    }
}
