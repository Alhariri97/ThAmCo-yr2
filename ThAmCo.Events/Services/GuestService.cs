
namespace ThAmCo.Events.Services;

public class GuestService : IGuestService
{
    private readonly AppDbContext _context;

    public GuestService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Guest> GetAllGuests()
    {
        return _context.Guests.ToList();
    }

    public Guest GetGuestWithEvent(int id)
    {
        var guest = _context.Guests
            .Include(g => g.GuestBookings)
            .ThenInclude(gb => gb.Event)  // Ensure Event is loaded
            .FirstOrDefault(m => m.GuestId == id);
        return guest;
    }

    public bool CreateGuest(Guest guest)
    {
        try
        {
            _context.Add(guest);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
     }

    public Guest GetGuest(int id)
    {
       return _context.Guests.Find(id);
    }


    public bool UpdateGuest(GuestDTO guestDto, Guest guest)
    {
        try
        {
            guest.FirstName = guestDto.FirstName;
            guest.LastName = guestDto.LastName;
            guest.Email = guestDto.Email;
            guest.Phone = guestDto.Phone;
            _context.Update(guest);
            _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteGuest(int id)
    {
        try
        {
            var guest = _context.Guests.Find(id);
            _context.Guests.Remove(guest);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return true;
        }
    }

    public List<Guest> GetAvailableGuestForEvent(Event even)
    {
        var availableGuests = _context.Guests
            .Where(s => !s.GuestBookings.Any(e => e.Event.EventDate.Date == even.EventDate.Date))
            .ToList();
        return availableGuests;
    }
}
