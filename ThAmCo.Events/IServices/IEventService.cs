namespace ThAmCo.Events.IServices;
public interface IEventService
{
    
    /// <summary>
    /// Returns all Events
    /// </summary>
    /// <returns></returns>
    IEnumerable<Event> GetAllEvents();

    /// <summary>
    /// Create an event takes a Event view model 
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    Task<int?> CreateEvent(CreateEventFormViewModel viewModel);



    int? UpdateEvent(EditEventFormViewModel viewModel);
    /// <summary>
    /// This retruns the Events that a staff is not associated with
    /// will be used for example in adding events for a staff!
    /// </summary>
    /// <returns></returns>
    List<Event> GetEventsUnrelatedToAstaff(int id);


    /// <summary>
    /// simple and quicke useed when only need the Event entity
    /// and don't immediately require the related entities
    /// Returns an event if found or null  !
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Event GetSimpleEvent(int id);

    /// <summary>
    /// Retuns related Staffings and GuestBookings entities,
    /// as it fetches all the required data in a single query.
    /// Can beneficial to reduce the number of database queries.
    /// but also can be resource-intensive if there are a large number of related entities
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Event GetEagerEvent(int id);


    /// <summary>
    /// Method to add a Staff to an event 
    /// takes an event and a staff and it added the staff to the event and
    /// returns true when success!!
    /// </summary>
    /// <param name="staff"></param>
    /// <param name="evetn"></param>
    /// <returns></returns>
    bool AddStaffToEvent(Staff staff, Event eve);
    bool DeleteStaffFromEvent(Staff comingStaff, Event comingEvent);
    

    /// <summary>
    /// Mehtod to update foodBooking for an event 
    /// </summary>
    /// <param name="eve"></param>
    /// <param name="foodBookingId"></param>
    /// <returns></returns>
    bool UpdateFoodbookingForEvent(int eventId, int foodBookingId);


    /// <summary>
    /// Method to Cancel the foodBooking Make the refrence id Null 
    /// </summary>
    /// <param name="eventId"></param>
    /// <returns></returns>
    bool CancelFoodBooking(int eventId);

    /// <summary>
    /// Method to cancel A venue reservation
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="reservationId"></param>
    /// <returns></returns>
    Task<bool> CancelVenueReservation(int eventId , string reservationId);


    /// <summary>
    /// Method to cancel a foodBooking for an event
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="foodBooking"></param>
    /// <returns></returns>
    Task<bool> CancelFoodBooking(int eventId, int foodBooking);

    /// <summary>
    /// Method to rebook a venu to an event!
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="reservationId"></param>
    /// <returns></returns>
    Task<bool> UpdateVenuReservation(int eventId, string reservationId);

    /// <summary>
    /// Cancel event it cancels the food booking if there is one and cancels the venue reservation 
    /// if there is one, and empty the staff and guests. 
    /// and assigns the isCacneld prop to true.
    /// </summary>
    /// <param name="eventId"></param>
    /// <returns></returns>
    Task<bool> CancelEvent(int eventId);

    /// <summary>
    /// Deletes an event!
    /// </summary>
    /// <param name="eventId"></param>
    /// <returns></returns>
    bool DeleteEvent(int eventId);
}
