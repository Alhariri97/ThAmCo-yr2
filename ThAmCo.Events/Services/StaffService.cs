namespace ThAmCo.Events.Services; 

public class StaffService : IStaffService
{
    private readonly AppDbContext _context;

    public StaffService(AppDbContext context)

    {
        _context = context;
    }

    public IEnumerable<Staff> GetAllStaff()
    {
        var staffMembers = _context.Staffs.ToList();
        return staffMembers;
    }


    public List<Staff> GetAvailableStaffForEvent(Event even)
    {

        var availableStaff = _context.Staffs
            .Where(s => !s.Staffings.Any(e => e.Event.EventDate.Date == even.EventDate.Date))
            .ToList();        
        return availableStaff;

    }
    public Staff CreateStaff(StaffDTO staffDto)
    {
        if (staffDto.HieraData == null)
        {
            staffDto.HieraData = DateTime.Now.Date;
        }
        var staff = new Staff
        {
            FirstName = staffDto.FirstName,
            LastName = staffDto.LastName,
            FirstAider = staffDto.FirstAider,
            Position = staffDto.Position,
            PhoneNumber = staffDto.PhoneNumber,
            HieraData = staffDto.HieraData,
        };
        _context.Add(staff);
        _context.SaveChanges();
        return staff;
    }

    public Staff GetStaff(int id)
    {
        return _context.Staffs.Find(id); 
    }
    public Staff EditStaff(StaffDTO staffDto)
    {
        Staff staff = _context.Staffs.Find(staffDto.StaffId);

        staff.FirstName = staffDto.FirstName;
        staff.LastName = staffDto.LastName;
        staff.HieraData = staffDto.HieraData;
        staff.FirstAider = staffDto.FirstAider;
        staff.PhoneNumber = staffDto.PhoneNumber;
        staff.Position = staffDto.Position;

        _context.Update(staff);
        _context.SaveChangesAsync();
        Staff updatedStaff = _context.Staffs.Find(staffDto.StaffId);
        return updatedStaff;
    }

    public Staff GetDetailedStaf(int id)
    {
        var staff = _context.Staffs.Include(s => s.Staffings).ThenInclude(g => g.Event)
             .FirstOrDefault(m => m.StaffId == id); 
             return staff; 
    }

    public bool DeleteStaff(int id)
    {
        try
        {
            var staff = _context.Staffs.Find(id);
            if(staff == null)
            {
                return false;
            }
            _context.Staffs.Remove(staff);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

  
}
