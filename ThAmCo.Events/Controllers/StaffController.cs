namespace ThAmCo.Events.Controllers;


[Authorize]
public class StaffController : Controller
{
    
    private readonly IStaffService _staffService;
    private readonly IEventService _eventService;
    public StaffController( IStaffService staffService, IEventService eventService)
    {
        _staffService = staffService;
        _eventService = eventService;
    }

    // GET: Staff
    public IActionResult Index()
    {
        try
        {
            var staffMembers = _staffService.GetAllStaff();
            return View(staffMembers);
        }catch 
        {
            return View("Error", new ErrorViewModel("Something Went wrong while getting data from DB"));
        }
    }

    // GET: Staff/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Staff/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("FirstName,LastName,HieraData,FirstAider,PhoneNumber,Position")] StaffDTO staffDto)
    {   


        try
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _staffService.CreateStaff(staffDto);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    throw (new Exception("Something Went wrong while getting data from DB")); 
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(staffDto); // Return the view with validation errors
            }

        }
        catch(Exception ex)
        {
            return View("Error", new ErrorViewModel(ex.Message));

        }
    }

    // GET: Staff/Edit/5
    public IActionResult Edit(int id)
    {

        try
        {
            var staff = _staffService.GetStaff(id);
            if (staff == null)
            {
                return NotFound();
            }

            // Convert Staff entity to StaffDTO
            var staffDto = new StaffDTO(staff);

            return View(staffDto);
        }
        catch
        {
            return View("Error", new ErrorViewModel("Something Went wrong while getting data from DB"));
        }
    }


    // POST: Staff/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("StaffId,FirstName,LastName,HieraData,FirstAider,PhoneNumber,Position")] StaffDTO staffDto)
    {
        if (id != staffDto.StaffId)
        {
            return NotFound();
        }
        if (!ModelState.IsValid)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(staffDto); // Return the view with validation errors
        }


        Staff staff = _staffService.GetStaff(id);
        if (staff == null)
        {
            return NotFound();
        }
        try
        {
            _staffService.EditStaff(staffDto);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View("Error", new ErrorViewModel("Something Went wrong while getting data from DB"));
        }


    }

    // GET: Staff/Details/5

    public IActionResult Details(int id)
    {

        try
        {
            var staff = _staffService.GetDetailedStaf(id);

            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }
        catch
        {
            return View("Error", new ErrorViewModel("Something Went wrong while getting data from DB"));
        }
    }

    // GET: Staff/Delete/5
    public IActionResult Delete(int id)
    {
        try
        {

            var staff = _staffService.GetStaff(id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }
        catch
        {
            return View("Error", new ErrorViewModel("Something Went wrong while getting data from DB"));
        }
    }

    // POST: Staff/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        try
        {
            var hasBeenDeleted = _staffService.DeleteStaff(id);
            if (hasBeenDeleted)
            {
                return RedirectToAction(nameof(Index));
            }
            throw new Exception("Something Went wrong while deleting the staff");
        }catch(Exception ex)
        {
            return View("Error", new ErrorViewModel(ex.Message));
        }
    }

    // GET: Staff/AddToEvent/5
    public IActionResult AddToEvent(int id)
    {
        var staff =  _staffService.GetStaff(id);
        if (staff == null)
        {
            return NotFound();
        }

        // Get all unrelated Events to this staff
        var events = _eventService.GetEventsUnrelatedToAstaff(id);

        AddToEventViewModel viewModel = new ()
        {
            Events = events,
            Staff = staff
        };

        return View(viewModel);
    }

    // POST: Staff/AddToEvent/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddToEvent(int staffId, int eventId)
    {
        var staff = _staffService.GetStaff(staffId);
        var @event = _eventService.GetSimpleEvent(eventId);

        if (staff != null && @event != null)
        {
            try
            {
                var success = _eventService.AddStaffToEvent(staff, @event);
                if (success)
                {
                    return RedirectToAction(nameof(Details), new { id = staffId });
                }
                else
                {
                    throw new Exception("You can't add this staff to this event he is on other event!");
                }
            }
            catch(Exception ex)
            {
                return View("Error", new ErrorViewModel(ex.Message));

            }

        }
        return View("Error", new ErrorViewModel("Something Went wrong Make sure the staff and event are booth exsit"));
    }


    // GET: Staff/DeleteFromEvent/5
    public IActionResult DeleteFromEvent(int staffId, int eventId)
    {

        try
        {
            var staff = _staffService.GetStaff(staffId);
            var @event = _eventService.GetSimpleEvent(eventId);
            if (staff == null || @event == null)
            {
                return NotFound();
            }

            DeleteFromEventViewModel viewModel = new()
            {
                Staff = staff,
                Event = @event
            };

            return View(viewModel);
        }
        catch
        {
            return View("Error", new ErrorViewModel("Something Went wrong while getting data from DB"));

        }


    }
    // POST: Staff/DeleteFromEvent/5
    [HttpPost, ActionName("DeleteFromEvent")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteFromEventConfirmed(int staffId, int eventId)
    {
        var staff = _staffService.GetStaff(staffId);
        var eve = _eventService.GetSimpleEvent(eventId);
        if (staff != null && eve != null)
        {
            try
            {
                var success = _eventService.DeleteStaffFromEvent(staff, eve);
                if (success)
                {
                    return RedirectToAction(nameof(Details), new { id = staffId });
                }
            }
            catch 
            {
                throw new Exception("Something Went wrong while deletein the staff from this event!");
            }
        }
        return View("Error", new ErrorViewModel("Something Went wrong Make sure the staff and event are booth exsit"));

    }

}
