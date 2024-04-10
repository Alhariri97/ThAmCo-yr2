namespace ThAmCo.Events.Controllers;

[Authorize]
public class GuestController : Controller
{
    private readonly IGuestService _guestService;

    public GuestController(IGuestService guestService)
    {
        _guestService = guestService;
    }

    // GET: Guest
    public IActionResult Index()
    {
        try
        {
            var guests = _guestService.GetAllGuests();
            return View(guests);
        }
        catch
        {
            return View("Error", new ErrorViewModel("Something Went wrong while getting data from DB"));
        }
        
    }

    // GET: Guest/Details/5
    public IActionResult Details(int id)
    {
        try
        {
            var guest = _guestService.GetGuestWithEvent(id);
            if (guest == null)
            {
                return NotFound();
            }
            return View(guest);

        }
        catch
        {
            return View("Error", new ErrorViewModel("Something Went wrong while getting data from DB"));
        }
    }

    // GET: Guest/Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("FirstName,LastName,Email,Phone")] GuestDTO guestDto)
    {
        if (ModelState.IsValid)
        {
            var guest = MapGuestDtoToGuest(guestDto);
            var success = _guestService.CreateGuest(guest);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Error", new ErrorViewModel("Something Went wrong while creating the Guest!"));
        }
        var errors = ModelState.Values.SelectMany(v => v.Errors);
        return View(guestDto);
    }
    // GET: Guest/Edit/5
    [HttpGet]
    public IActionResult Edit(int id)
    {
        try
        {

            var guest = _guestService.GetGuest(id);

            if (guest == null)
            {
                return NotFound();
            }
            return View(guest);
        }
        catch
        {
            return View("Error", new ErrorViewModel("Something Went wrong while geting the Guest from DB!"));

        }
    }

    // POST: Guest/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, [Bind("GuestId,FirstName,LastName,Email,Phone")] GuestDTO guestDto)
    {
        if (id != guestDto.GuestId)
        {
            return View("Error", new ErrorViewModel("The guest id and url parameters are not matched!", 400));
        }

        if (ModelState.IsValid)
        {
            try
            {
                var guest = _guestService.GetGuest(id);
                if (guest == null)
                {
                    return NotFound();
                }
                var success = _guestService.UpdateGuest(guestDto, guest);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Error", new ErrorViewModel("Something Went wrong while updating the Guest in DB!"));
                }
            }
            catch
            {
                return View("Error", new ErrorViewModel("Something Went wrong, try again!"));
            }
        }
        else
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(guestDto);
        }
    }


    // GET: Guest/Delete/5
    public IActionResult Delete(int id)
    {
        try
        {
            var guest = _guestService.GetGuest(id);

            if (guest == null)
            {
                return NotFound();
            }

            return View(guest);
        }
        catch
        {
            return View("Error", new ErrorViewModel("Something Went wrong, try again!"));
        }
    }

    // POST: Guest/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var guest = _guestService.GetGuest(id);
        if (guest == null)
        {
            return NotFound();
        }
        try
        {
            var success = _guestService.DeleteGuest(id);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error", new ErrorViewModel("Something Went wrong while deleting the Guest in DB!"));

            }
        }
        catch
        {
            return View("Error", new ErrorViewModel("Something Went wrong, try again!"));
        }
    }


    /// <summary>
    /// Mapping here Not in the service; 
    /// </summary>
    /// <param name="guestDto"></param>
    /// <returns></returns>
    private static Guest MapGuestDtoToGuest(GuestDTO guestDto)
    {
        return new Guest
        {
            FirstName = guestDto.FirstName,
            LastName = guestDto.LastName,
            Email = guestDto.Email,
            Phone = guestDto.Phone
        };
    }

}
