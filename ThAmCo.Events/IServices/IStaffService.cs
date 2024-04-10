namespace ThAmCo.Events.IServices;
public interface IStaffService
{



    /// <summary>
    /// Return all Staff!
    /// </summary>
    /// <returns></returns>
    IEnumerable<Staff> GetAllStaff();

    /// <summary>
    /// Create a stff 
    /// </summary>
    /// <param name="staffDto"></param>
    /// <returns></returns>
    Staff CreateStaff(StaffDTO staffDto);
    /// <summary>
    /// Get a staff by its Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Staff GetStaff(int id);
    /// <summary>
    /// Update staff
    /// </summary>
    /// <param name="staffDto"></param>
    /// <returns></returns>
    Staff EditStaff(StaffDTO staffDto);

    /// <summary>
    /// REturns an egaer staff
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Staff GetDetailedStaf(int id);

    /// <summary>
    /// deletes a staff
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    bool DeleteStaff(int id);

    /// <summary>
    /// return all avalible staff for an event 
    /// where it checks dates of the event and return all avalible staff
    /// for that data
    /// </summary>
    /// <param name="even"></param>
    /// <returns></returns>
    List<Staff> GetAvailableStaffForEvent(Event even);
}
