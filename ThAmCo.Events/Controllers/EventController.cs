using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Security.Claims;
using ThAmCo.Events.Models;

namespace ThAmCo.Events.Controllers;

[Authorize]
public class EventController : Controller
{
    private readonly IStaffService _staffService;
    private readonly IGuestService _guestService; 
    private readonly IVenuesService _venuesService;
    private readonly IEventService _eventService;
    private readonly ICateringService _cateringService;
    
    public EventController(IStaffService staffService,
                            IGuestService guestService, 
                            IVenuesService venuesService,
                            IEventService eventService,
                            ICateringService cateringService)
    {
        _staffService = staffService;
        _guestService = guestService;
        _venuesService = venuesService;
        _eventService = eventService;
        _cateringService = cateringService;
    }
    public IActionResult Index()
    {
         var a =  User.Claims;
        var userRoles = User.FindAll(ClaimTypes.Role).Select(c => c.Value);

        var events = _eventService.GetAllEvents();
        // Convert each Event to DisplayEventsFromViewModel using the static method
        var displayEvents = events.Select(DisplayEventsFromViewModel.FromEvent).ToList();

        return View(displayEvents);
    }

    //[Authorize(Roles = "Manager")]
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        CreateEventFormViewModel viewModel = new();
        try
        {
            var readyModel  = await BuildViewModel(viewModel);
            return View(readyModel);
        }
        catch
        {
            return View("Error", new ErrorViewModel("Something Went wrong !"));
        }

    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public  async Task<IActionResult> Create(CreateEventFormViewModel model)
    {

        if (!ModelState.IsValid)
        {
            
            var readyModel = await BuildViewModel(model);
            return View(readyModel);
        }
        try
        {

            var isEventCreaed = await _eventService.CreateEvent(model) ?? throw new Exception("could not created an event now!");

            // If event has been created and did not throw
            // check if there is a menu if yes, try and book the food for it 

            if (model.SelectedMenuId != null)
            {
                try
                {
                    var foodBooking = new FoodBookingDTO
                    {
                        NumberOfGuests = 0,
                        MenuId = (int)model.SelectedMenuId,
                        FoodBookingDate = model.EventDate,
                        ClientReferenceId = isEventCreaed
                    };

                    var foodFookingCreatedId = await _cateringService.CreateFoodBooking(foodBooking);

                    if (foodFookingCreatedId.HasValue)
                    {
                        var updatedTheEvent = _eventService.UpdateFoodbookingForEvent(isEventCreaed, foodFookingCreatedId.Value);
                    }

                }
                catch
                {
                    throw new Exception("Event creaetd it but could not book food now!");
                }
            }

            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return View("Error", new ErrorViewModel( ex.Message));

        }

    }


    public  IActionResult Details(int id)
    {
        var eventFromDb = _eventService.GetEagerEvent(id);
        if (eventFromDb == null)
        {
            return View("Error", new ErrorViewModel("Event could not be found"));
        }
        if (eventFromDb.IsCanceled)
        {
            return View("Error", new ErrorViewModel("Event has been canceled, you can't not view it."));
        }
        DetailsEventFormViewModel detailsView = BuildDetailsView(eventFromDb);

        return View(detailsView);
    }

    public async Task<IActionResult> Edit(int id)
    {

        var eventFromDb = _eventService.GetSimpleEvent(id);

        if (eventFromDb == null)
        {
            return View("Error", new ErrorViewModel("Event could not be found"));
        }
        if (eventFromDb.IsCanceled)
        {
            return View("Error", new ErrorViewModel("Event has been canceled, you can't not edit it."));
        }


        EditEventFormViewModel initalViewMode = new ()
        {
            EventId = eventFromDb.EventId
            // Set other properties as needed
        };

        EditEventFormViewModel viewMode = await BuildEditView(initalViewMode);

        return View(viewMode);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditEventFormViewModel model)
    {
        var eventFromDb = _eventService.GetSimpleEvent(model.EventId);
        if (eventFromDb.IsCanceled)
        {
            return View("Error", new ErrorViewModel("Event has been canceled, you can't not edit it."));
        }
        if (eventFromDb.IsCanceled)
        {
            return View("Error", new ErrorViewModel("Event has been canceled, you can't not edit it."));
        }
        if (!ModelState.IsValid)
        {

            EditEventFormViewModel viewMode = await BuildEditView(model);


            return View(viewMode);
        }


        // if a menu selected then create a food booking!
        if (model.SelectedMenuId != null)
        {
            try
            {
                var foodBooking = new FoodBookingDTO
                {
                    NumberOfGuests = model.SelectedGuests.Count,
                    MenuId = (int)model.SelectedMenuId,
                    FoodBookingDate = model.EventDate,
                    ClientReferenceId = model.EventId
                };

                var foodFookingCreatedId = await _cateringService.CreateFoodBooking(foodBooking);

                if (foodFookingCreatedId.HasValue)
                {
                    var updatedTheEvent = _eventService.UpdateFoodbookingForEvent(model.EventId, foodFookingCreatedId.Value);
                }

            }
            catch
            {
                throw new Exception("Event creaetd it but could not book food now!");
            }
        }


        // if a avalibliy selected then try to book a new Vene
        // the req file provided says the user can't change the date. 
        // here he is not changeing the date but he's booking a new Venue booking 
        // by canceling the old booking and looking for a new one.
        // Hope this what you meant!
        string jsonString = model.SelectedAvailability;
        if (!string.IsNullOrEmpty(jsonString))
        {

            bool rebook = await _eventService.UpdateVenuReservation(model.EventId, jsonString);
            if (rebook)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        _eventService.UpdateEvent(model);

        return RedirectToAction(nameof(Index));

    }

    public async Task<IActionResult> Cancel(int eventId)
    {
        var eventFromDb = _eventService.GetEagerEvent(eventId);
        if (eventFromDb == null)
        {
            return View("Error", new ErrorViewModel("Event could not be found"));
        }

        var isCanceled = await _eventService.CancelEvent(eventId);

        return isCanceled ? Ok() : NotFound();
    }
    [HttpPut]
    public IActionResult Delete(int eventId)
    {
        var eventFromDb = _eventService.GetEagerEvent(eventId);
        if (eventFromDb == null)
        {
            return View("Error", new ErrorViewModel("Event could not be found"));
        }

        var isDelete =  _eventService.DeleteEvent(eventId);

        return isDelete ? Ok() : NotFound();
    }

    private async Task<EditEventFormViewModel> BuildEditView(EditEventFormViewModel viewModel)
    {
        // Get the event from the db load all the staff and guests related
        var eventDb = _eventService.GetEagerEvent(viewModel.EventId);


        // Get the staff that already in this event 
        List<Staff> staffInEvent = eventDb.Staffings.Select(s => s.Staff).ToList();
        // Get avalible on this event date from db!
        List<Staff> availableStaffAsSelectList = _staffService.GetAvailableStaffForEvent(eventDb);
        // Adde  the available to the excisting staff
        List<Staff> result = availableStaffAsSelectList.Concat(staffInEvent).ToList();
        // Convert List to a select list item 
        var selectListForStaff = result.Select(s => new SelectListItem
        {
            Value = s.StaffId.ToString(), 
            Text = s.FullName 
        });
        viewModel.Staffs = selectListForStaff;

        // Get the already excisting IDs and put them in an int list so can be rendered in view as selected.
        List<int> staffInEventIds = staffInEvent.Select(s => s.StaffId).ToList();
        viewModel.SelectedStaffs = staffInEventIds;

        // Now the same for the guests
        List<Guest> guestsInEvent = eventDb.GuestBookings.Select(s => s.Guest).ToList();
        List<Guest> availableGuestsAsSelectList = _guestService.GetAvailableGuestForEvent(eventDb);
        List<Guest> resultForAll = availableGuestsAsSelectList.Concat(guestsInEvent).ToList();
        var selectListForGuests = resultForAll.Select(s => new SelectListItem
        {
            Value = s.GuestId.ToString(),
            Text = s.FullName
        });
        viewModel.Guests = selectListForGuests;

        List<int> guestInEventIds = guestsInEvent.Select(s => s.GuestId).ToList();
        viewModel.SelectedGuests = guestInEventIds;

        // I don't like the coming code :(
        // Get the list of GuestIds already assigned to the event
        viewModel.EventName = eventDb.EventName;
        viewModel.EventDate = eventDb.EventDate;
        viewModel.EventTypeName = eventDb.EventTypeName;

        viewModel.EventTypeId = eventDb.EventTypeId;  
        viewModel.FoodBookingId = string.IsNullOrEmpty(eventDb.FoodBookingId) ?
            viewModel.FoodBookingId : eventDb.FoodBookingId;
        viewModel.ReservationId = string.IsNullOrEmpty(eventDb.ReservationId) ?
            viewModel.ReservationId : eventDb.ReservationId;
        
        //viewModel.Guests = availableGuests;


        if (!string.IsNullOrEmpty(eventDb.ReservationId))
        {
            viewModel.Reservation = await _venuesService.GetReservation(eventDb.ReservationId);

        }
        if (int.TryParse(eventDb.FoodBookingId, out int parsedNumber))
        {
            viewModel.FoodBooking = await _cateringService.GetFoodBooking(parsedNumber);
            viewModel.Menu = await _cateringService.GetMenuWithFoodItems(viewModel.FoodBooking.MenuId);
        }
        else
        {
            var menus = await _cateringService.GetAllMenus();
            var selectListItems = menus.Select(menu => new SelectListItem
            {
                Value = menu.MenuId.ToString(),
                Text = menu.MenuName
            });
            viewModel.MenusForBooking = selectListItems;
        }


        return viewModel;
    }


    private async Task<CreateEventFormViewModel> BuildViewModel(CreateEventFormViewModel model)
    {

        model.EventtypesFromApi = await _venuesService.GeteventTypeListAsSelectListItem();

        var menus = await _cateringService.GetAllMenus();
        var selectListItems = menus.Select(menu => new SelectListItem
        {
            Value = menu.MenuId.ToString(),
            Text = menu.MenuName
        });
        model.MenusForBooking = selectListItems;

        return model;          
    }
    private DetailsEventFormViewModel BuildDetailsView(Event eventFromDb)
    {
        var staffInEvent = eventFromDb.Staffings
            .Where(s => s.Staff != null)
            .Select(s => new StaffDTO(s.Staff)).ToList();
        var guestsInEvent = eventFromDb.GuestBookings
            .Where(s => s.Guest != null)
           .Select(s => new GuestDTO(s.Guest)).ToList();

        DetailsEventFormViewModel detailsView = new()
        {
            Staff = staffInEvent,
            Guests = guestsInEvent,
            EventDate = eventFromDb.EventDate,
            EventName = eventFromDb.EventName,
            EventTypeName = eventFromDb.EventTypeName,
            EventTypeId = eventFromDb.EventTypeId,
            ReservationId = eventFromDb.ReservationId,
            FoodBookingId = eventFromDb.FoodBookingId,
            EventId = eventFromDb.EventId,
        };

        return detailsView;
    }

    [HttpPut]
    public async Task<IActionResult> CancelVenue(int eventId, string reservationId)
    {
        var isCanceled = await _eventService.CancelVenueReservation(eventId, reservationId);
        return isCanceled ? Ok() : NotFound();
    }
    [HttpPut]
    public async Task<IActionResult> CancelFoodBooking(int eventId, int foodBookingId)
    {
        var isCanceled = await _eventService.CancelFoodBooking(eventId, foodBookingId);
        return isCanceled ? Ok
            () : NotFound();
    }


    [HttpPut]



    public IActionResult Error(ErrorViewModel eroro)
    {
        // Retrieve the exception message from the route data
        var error = HttpContext.Features.Get<IExceptionHandlerFeature>();
        ViewBag.ErrorMessage = error?.Error?.Message;

        return View(eroro);
    }

}
