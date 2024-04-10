
namespace ThAmCo.Events.Controllers;

[Authorize]
public class CateringController : Controller
{
    private readonly ICateringService _cateringService;
    private readonly IEventService _eventService;
    public CateringController(ICateringService cateringService, IEventService eventService)
    {
        _cateringService = cateringService;
        _eventService = eventService;
    }

    public async Task<IActionResult> Index()
    {
        var foodBookings = await _cateringService.GetAllFoodBookings();

        var foodBookingViewModels = foodBookings.Select(food =>
        {
            var foodBookingViewModel = new FoodBookingViewModel(_eventService, food);
           return foodBookingViewModel;
        }).ToList();

        return View(foodBookingViewModels);
    }

    [HttpGet]// Used in Ajax
    public async Task<IActionResult> FoodItems()
    {
        var foodItems = await _cateringService.GetAllFoodItems();
        return View(foodItems);
    }

    [HttpGet]// Used in Ajax
    public async Task<IActionResult> Details(int id)
    {
        var foodBookings = await _cateringService.GetFoodBooking(id);
        DisplayFoodBookingDetailsViewModel detailsViewModel = new(_eventService, foodBookings)
        {
            Menu = await _cateringService.GetMenuWithFoodItems(foodBookings.MenuId)
        };

        //var detailsViewModel = foodBookings
        return View(detailsViewModel);
    }

    [HttpGet] // Used in Ajax
    public async Task<IActionResult> Edit(int id)
    {
        var foodbooking = await _cateringService.GetFoodBooking(id);
        //Convert the foodBooking to edit view meode!
        EditFoodBookingViewModel editFoodBookingViewModel = new(foodbooking)
        {
            Menu = await _cateringService.GetMenuWithFoodItems(foodbooking.MenuId)
        };

        // if no event is associated to the food booking
        if (editFoodBookingViewModel.ClientReferenceId.HasValue)
        {
            editFoodBookingViewModel.Event = _eventService.GetSimpleEvent(editFoodBookingViewModel.ClientReferenceId.Value);
        }
        else
        {
            editFoodBookingViewModel.Event = null; // Default value 
            var events = _eventService.GetAllEvents();
            var eventsWithotBooking = events.Where(m =>  string.IsNullOrEmpty(m.FoodBookingId))
                .Select(m => new SelectListItem
                {
                    Value = m.EventId.ToString(),
                    Text = m.EventName
                });  // if no client referencid then now event associated to this booking user can then chooes

            editFoodBookingViewModel.EventWithouBooking = eventsWithotBooking;
        }
        

        var menus = await _cateringService.GetAllMenus();
        editFoodBookingViewModel.MenusAvailable = menus
            .Where(menu => menu.MenuId != editFoodBookingViewModel.MenuId) // exclude the menu already there
            .Select(menu => new SelectListItem // convert the menus to
            {
                Value = menu.MenuId.ToString(),
                Text = menu.MenuName
            });

        return View(editFoodBookingViewModel);
    }


    [HttpPost]
    public async Task<IActionResult> Edit(EditFoodBookingViewModel editFoodBookingViewModel)
    {


        if (ModelState.IsValid)
        {
            var oldBooking = await _cateringService.GetFoodBooking(editFoodBookingViewModel.FoodBookingId);
            oldBooking.MenuId = editFoodBookingViewModel.MenuId;
            oldBooking.NumberOfGuests = editFoodBookingViewModel.NumberOfGuests;
            var needUpdateEvent = editFoodBookingViewModel.ClientReferenceId != null; //do we need to update the event ? if it is null then no
            var hasEventBeenUpdated = false;

            if (needUpdateEvent)
            {
                oldBooking.ClientReferenceId = editFoodBookingViewModel.ClientReferenceId;
                var eventChosen = _eventService.GetSimpleEvent(editFoodBookingViewModel.ClientReferenceId.Value);
                // update the event foodbooking id
                hasEventBeenUpdated = _eventService.UpdateFoodbookingForEvent(eventChosen.EventId, oldBooking.FoodBookingId);

                oldBooking.FoodBookingDate = eventChosen.EventDate; 
            }
            // if we do need to update the event then check if that has been successed 
            // 
            if (needUpdateEvent)
            {
                if (hasEventBeenUpdated)
                {
                    var isUpdated = await _cateringService.EditFoodBooking(oldBooking.FoodBookingId, oldBooking);
                    if (isUpdated)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    //if we did update the event but could not update teh food booking, cancel the event food booking we made at line 99.
                    _eventService.CancelFoodBooking(oldBooking.FoodBookingId);  
                    return View("Error", new ErrorViewModel("Something Went wrong while updating food booking data!"));

                }
                else
                {
                    return View("Error", new ErrorViewModel("Something Went wrong while trying to update Event data!"));
                }

            }
            else
            {
                var isUpdated = await _cateringService.EditFoodBooking(oldBooking.FoodBookingId, oldBooking);
                if (isUpdated)
                {
                    return RedirectToAction(nameof(Index));
                }

            }


        }
        else
        {
            return RedirectToAction(nameof(Index));

        }


        return RedirectToAction(nameof(Index));
    }

    [HttpPut]
    public async Task<IActionResult> CancelFoodBooking(int id)
       
    {
        var isCanceled = false;
        var cacelInEvent = false;
        var foodbooking = await _cateringService.GetFoodBooking(id);
        if (foodbooking != null) {
            cacelInEvent = _eventService.CancelFoodBooking(foodbooking.ClientReferenceId.Value);

            isCanceled = await _cateringService.CancelFoodBooking(id);
        }
        return (isCanceled && cacelInEvent) ? Ok(): NotFound();
    }
    public async Task<IActionResult> DeleteFoodBooking(int id)
    {
        var isDeleted = await _cateringService.DeleteFoodBooking(id);
        return isDeleted ? Ok() : NotFound() ;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFoodItem(float price, string name, string desc)
    {

        var foodItem = new PostFoodItemDTO() { Description= desc, Name = name, UnitPrice = price};

        var created = await _cateringService.CreateFoodItem(foodItem);

        return created ? Ok () : NotFound();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteFoodItem(int id)
    {
        var created = await _cateringService.DeleteFoodItem(id);

        return created ? Ok() : NotFound();
    }

    [HttpGet]// Used in Ajax
    public async Task<IActionResult> FoodItemDetails(int id)
    {
        var created = await _cateringService.GetFoodItem(id);
        return Ok(created); 
    }

    [HttpPut]// Used in Ajax
    public async Task<IActionResult> EditFoodItem(int id, float price, string name, string desc)
    {
        FoodItemDTO foodItem = new() { Description = desc, FoodItemId = id, Name = name, UnitPrice = price }; 
        var created = await _cateringService.EditFoodItem(id, foodItem);
        return created ? Ok(): NotFound() ;
    }

    [HttpGet]// Used in Ajax
    public async Task<IActionResult> Menus()
    {
        var menus = await _cateringService.GetAllMenus();
        return View(menus);
    }

    [HttpGet]// Used in Ajax
    public async Task<IActionResult> GetMenuWithFoodItems(int id)
    {
        var menu = await _cateringService.GetMenuWithFoodItems(id );
        return Ok(menu);
    }
    [HttpGet]// Used in Ajax
    public async Task<IActionResult> GetAllFoodItemsForMenu(int id)
    {
        var foodItems = await _cateringService.GetAllFoodItems();
        var menu = await _cateringService.GetMenuWithFoodItems(id);
        // Extract the Ids of food items in the menu
        var foodItemIdsInMenu = menu.FoodItems.Select(f => f.FoodItemId).ToList();
        // Exclude food items that are already in the menu
        var newFoodItems = foodItems.Where(f => !foodItemIdsInMenu.Contains(f.FoodItemId)).ToList();
        return Ok(newFoodItems);
    }
   
    
    [HttpPut]// Used in Ajax
    [Route("/Catering/EditMenuFoodItems/{menuId}")]
    public async Task<IActionResult> EditMenuFoodItems(int menuId, int[] numbers)
    {
        var menuEdit = await _cateringService.EditFoodItemsInMenu(menuId, numbers);

        return menuEdit ? Ok() : NotFound();
    }
   
    [HttpPost]// Used in Ajax
    public async Task<IActionResult> CreateMenu(string name)
    {
        var created = await _cateringService.CreateMenu(name);

        return created ? Ok() : NotFound();
    }

    [HttpPut]// Used in Ajax
    public async Task<IActionResult> UpdateMenu(int menuId, string newName)
    {
        var updated = await _cateringService.EditMenu(menuId, newName);
        return updated ? Ok() : NotFound();
    }
    [HttpDelete] // Used in Ajax
    public async Task<IActionResult> DeleteMenu(int menuId)
    {
        var updated = await _cateringService.DeleteMenu(menuId);
        return updated ? Ok() : NotFound();
    }
}

