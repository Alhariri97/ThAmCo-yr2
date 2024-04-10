namespace ThAmCo.Events.IServices;
public interface IVenuesService
{

    /// <summary>
    /// It's clear each method what it does, and it's provided by you!
    /// </summary>
    /// <returns></returns>
    Task<List<EventTypeDTO>> GetEventtypes();
    Task<ReservationDTO> GetReservation(string reservationCode);
    Task<bool> DeleteReservation(string reservationCode);
    Task<ReservationDTO> CreateReservation(PostReservationDTO reservationData);
    Task<List<SelectListItem>> GeteventTypeListAsSelectListItem();
}
