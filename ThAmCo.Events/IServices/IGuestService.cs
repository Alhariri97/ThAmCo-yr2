namespace ThAmCo.Events.IServices;
public interface IGuestService
{
    IEnumerable<Guest> GetAllGuests();


    /// <summary>
    /// REturns the guests with events assosiated with heavy loading1
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Guest GetGuestWithEvent(int id);
    bool CreateGuest(Guest guest);
    Guest GetGuest(int id);


    /// <summary>
    /// It's not a good practice to use the DTO as a prameter for a service or a return vlaue.
    /// However sence this is not a real word project and not gonna be deployed live, prod, or used.
    /// nothing wrong going this way.
    /// ///
    /// That's why you find me maping on GuestController line 176 ( MapGuestDtoToGuest ) to turn a GuestDTO to a Guest!
    /// </summary>
    /// <param name="guestDto"></param>
    /// <param name="guest"></param>
    /// <returns></returns>
    bool UpdateGuest(GuestDTO guestDto, Guest guest);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool DeleteGuest(int id);



    /// <summary>
    /// Get all Avaalible guests for an event!
    /// </summary>
    /// <param name="even"></param>
    /// <returns></returns>
    List<Guest> GetAvailableGuestForEvent(Event even);
}
