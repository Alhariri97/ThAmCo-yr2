using Microsoft.EntityFrameworkCore;
using ThAmCo.Catering.Models;
using ThAmCo.Events.Models;
using ThAmCo.Venues.Data;

namespace ThAmCo.Events.Services;

public class EventService : IEventService
{
    private readonly AppDbContext _context;
    private readonly IVenuesService _venuesService;
    private readonly ICateringService _cateringService;

    public EventService(AppDbContext context, IVenuesService venuesService, ICateringService cateringService)

    {
        _context = context;
        _venuesService = venuesService;
        _cateringService = cateringService;
    }
    IEnumerable<Event> IEventService.GetAllEvents()
    {
        // AsNoTracking to improves the preformance as we won't need to keep track any changes to the events here.
        return _context.Events
            .Include(e =>e.Staffings)
            .ThenInclude(s => s.Staff)
            .Include(e => e.GuestBookings)
            .AsNoTracking().ToList();
    }
    public async Task<int?> CreateEvent(CreateEventFormViewModel viewModel)
    {

        try
        {
            Event newEvent = new()
            {
                EventName = viewModel.EventName,
                EventTypeName = viewModel.EventTypeName,
                EventTypeId = viewModel.EventTypeId,
                FoodBookingId = viewModel.FoodBookingId,
                EventDate = viewModel.EventDate,
            };

            if (!string.IsNullOrEmpty(viewModel.SelectedAvailability))
            {

                string jsonString = viewModel.SelectedAvailability;
                VenueDTO availability = JsonConvert.DeserializeObject<VenueDTO>(jsonString);
                PostReservationDTO reservationPostObject = new()
                {
                    EventDate = availability.Date,
                    StaffId = "1",
                    VenueCode = availability.Code
                };
                var reservation = await _venuesService.CreateReservation(reservationPostObject);

                newEvent.EventDate = reservation.EventDate;
                newEvent.ReservationId = reservation.Reference;
                try
                {
                    _context.Add(newEvent);
                    _context.SaveChanges();
                    return newEvent.EventId;
                }
                catch
                {
                    throw new InvalidOperationException("An error occurred while processing the request.");
                }

            }
            try
            {
                _context.Add(newEvent);
                _context.SaveChanges();
                return newEvent.EventId;
            }
            catch
            {
                throw new InvalidOperationException("An error occurred while processing the request.");
            }
        }
        catch
        {
            return null;
        }
    }

    public int? UpdateEvent(EditEventFormViewModel viewModel)
    {
        Event ev = _context.Events.Find(viewModel.EventId);
        ev.EventDate = viewModel.EventDate;
        var eve = _context.Events
            .Include(e => e.Staffings) // Include the Staffings navigation property
             .Include(e => e.GuestBookings) // Include the Staffings navigation property
            .FirstOrDefault(e => e.EventId == ev.EventId);

        if (eve != null)
        {
            // Clear all staff associations
            eve.Staffings.Clear();
            eve.GuestBookings.Clear();
            eve.EventName = viewModel.EventName; ;
            _context.SaveChanges();
        }

        foreach(int id in viewModel.SelectedGuests)
        {
            var guests = _context.Guests.Find(id);
            GuestBooking asdf = new()
            {
                Event = ev,
                Guest = guests,

            };
            eve.GuestBookings.Add(asdf);
            _context.SaveChanges();
        }
        foreach (int id in viewModel.SelectedStaffs)
        {
            var staffs = _context.Staffs.Find(id);
            Staffing fuckThis = new()
            {
                Event = ev,
                Staff = staffs,

            };
            eve.Staffings.Add(fuckThis);
            _context.SaveChanges();
        }

        var a = _context.Events.Find(ev.EventId);

        return ev.EventId;

    }


    public List<Event> GetEventsUnrelatedToAstaff(int id)
    {
        // Retrieve events to display in the view

        var events = _context.Events
            .Where(e => !e.Staffings.Any(s => s.StaffId == id))
            .ToList();
        return events;
    }
    
    public Event GetEagerEvent(int id)
    {
        var fullEvent = _context.Events.Include(e => e.Staffings).ThenInclude(s=>s.Staff)
            .Include(e=>e.GuestBookings).Include(e => e.GuestBookings).ThenInclude(g => g.Guest)
            .FirstOrDefault(e => e.EventId == id);

        return fullEvent;
    }
    public Event GetSimpleEvent(int id)
    {
        return _context.Events.Find(id);
    }

    public bool AddStaffToEvent(Staff staff, Event eve)
    {
        var isStaffAva = IsStaffAvailableForEvent(staff, eve.EventDate);
        if (isStaffAva)
        {
            return false;
        }
        try
        {
            eve.Staffings.Add(new Staffing { Staff = staff, Event = eve });
            _context.SaveChanges();
        }
        catch
        {
            return false;
        }
        return true;
    }


    /// <summary>
    /// Method for to return an event with its staffings eager loading!
    /// Return an event Staffings included
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Event GetEventWithStaffings(int id)
    {
        var eve =  _context.Events
            .Include(e => e.Staffings)
            .FirstOrDefault(e => e.EventId == id);
        return eve;
    }

    /// <summary>
    /// Method to delete a staff from an event
    /// return true if success
    /// </summary>
    /// <param name="comingStaff"></param>
    /// <param name="comingEvent"></param>
    /// <returns></returns>
    public bool DeleteStaffFromEvent(Staff comingStaff, Event comingEvent)
    {

        var eve = _context.Events
            .Include(e => e.Staffings)
            .FirstOrDefault(e => e.EventId == comingEvent.EventId); 
        var staffing = eve.Staffings.FirstOrDefault(s => s.StaffId == comingStaff.StaffId);
        if (staffing != null)
        {
            eve.Staffings.Remove(staffing);
            _context.SaveChanges();
            return true;
        }
        return false;
    }


    public bool UpdateFoodbookingForEvent(int eventId, int foodBookingId)
    {
        var eventWanted =  _context.Events.Find(eventId);
        if (eventWanted == null)
        {
            return false;
        }
        eventWanted.FoodBookingId = foodBookingId.ToString();
        _context.SaveChanges();
        return true;
    }

    public bool CancelFoodBooking(int eventId)
    {
        var eventWanted = _context.Events.Find(eventId);
        if (eventWanted == null)
        {
            return false;
        }
        eventWanted.FoodBookingId = null;
        _context.SaveChanges();

        return true;
    }


    public async Task<bool> CancelFoodBooking(int eventId, int foodBooking)
    {
        var eventWanted = _context.Events.Find(eventId);
        if (eventWanted == null)
        {
            return false;
        }
        var isCanceled = await _cateringService.CancelFoodBooking(foodBooking);
        if(isCanceled ) {
            eventWanted.FoodBookingId = null;
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public async Task<bool> CancelVenueReservation(int eventId, string reservationId)
    {
        var eventWanted = _context.Events.Find(eventId);

        if (eventWanted == null)
        {
            return false;
        }

        var isCanceled = await _venuesService.DeleteReservation(reservationId);

        if (isCanceled)
        {
            // Assuming ReservationId is a string property
            eventWanted.ReservationId = null;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return true;
        }

        return false;
    }

    public async Task<bool> UpdateVenuReservation(int eventId, string jsonString)
    {
        var eventWanted = _context.Events.Find(eventId);

        if (eventWanted == null)
        {
            return false;
        }
        VenueDTO availability = JsonConvert.DeserializeObject<VenueDTO>(jsonString);
        PostReservationDTO reservationPostObject = new()
        {
            EventDate = availability.Date,
            StaffId = "1",
            VenueCode = availability.Code
        };

        var isReservationBooked = await _venuesService.CreateReservation(reservationPostObject);

        if (isReservationBooked != null)
        {
            eventWanted.ReservationId = isReservationBooked.Reference;
            eventWanted.EventDate = isReservationBooked.EventDate;
            _context.SaveChanges();
            return true;
        }
        return false;

    }

    public async Task<bool> CancelEvent(int eventId)
    {


        var eventWanted = _context.Events
        .Include(e => e.Staffings)
        .Include(e => e.GuestBookings)
        .FirstOrDefault(e => e.EventId == eventId);

        if (eventWanted == null)
        {
            return false;
        }

        // Look if we have foodBooking
        if (int.TryParse(eventWanted.FoodBookingId, out int foodBookingId))
        {
            await _cateringService.CancelFoodBooking(foodBookingId);
            eventWanted.FoodBookingId = null;
        }
        if (!string.IsNullOrEmpty(eventWanted.ReservationId))
        {
            await _venuesService.DeleteReservation(eventWanted.ReservationId);
            eventWanted.ReservationId = null;
        }

        // Remove all staff and guests from the event
        foreach (var staffing in eventWanted.Staffings.ToList())
        {
            eventWanted.Staffings.Remove(staffing);
        }
        foreach (var guest in eventWanted.GuestBookings.ToList())
        {
            eventWanted.GuestBookings.Remove(guest);
        }
        eventWanted.IsCanceled = true;
        _context.SaveChanges();
        return true;

    }
    public bool DeleteEvent(int eventId)
    {
        var eventWanted = _context.Events
        .Include(e => e.Staffings)
        .Include(e => e.GuestBookings)
        .FirstOrDefault(e => e.EventId == eventId);

        if (eventWanted == null)
        {
            return false;
        }

        // Look if we have foodBooking
        if (eventWanted.IsCanceled != true
            || !string.IsNullOrEmpty(eventWanted.FoodBookingId) 
            || !string.IsNullOrEmpty(eventWanted.ReservationId) 
            )
        {
            return false;
        }

        _context.Events.Remove(eventWanted);
        _context.SaveChanges();
        return true;

    }

    // Function to check if a staff member is available for an event
    public bool IsStaffAvailableForEvent(Staff staff, DateTime eventDate)
    {
        var staffWithEvents = _context.Staffs.Include(e => e.Staffings)
            .ThenInclude(e => e.Event) // Include the Staffings navigation property
            .FirstOrDefault(e => e.StaffId == staff.StaffId);

        return staffWithEvents.Staffings.Any(e => e.Event.EventDate == eventDate);
    }

}