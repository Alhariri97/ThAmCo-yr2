using ThAmCo.Catering.DTOs;
using ThAmCo.Catering.Models;

namespace ThAmCo.Catering.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenusController : ControllerBase
{
    private readonly DataContext _context;

    public MenusController(DataContext context)
    {
        _context = context;
    }

    // GET: api/Menus 
    /// <summary>
    /// Returns List of menuItemDTO
    /// </summary>
    /// <returns> List of menuItemDTO with status 200 if success </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuItemDTO>>> GetMenus()
    {
        try
        {
            var menus = await _context.Menus.OrderByDescending(m => m.MenuId).ToListAsync();
            List<MenuItemDTO> menuDto = menus.Select(x => new MenuItemDTO { 
                MenuId = x.MenuId,
                MenuName = x.MenuName,            
            }).ToList();
            return Ok(menuDto);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unable to Provide Data at this time");
        }
    }



    // GET: api/Menus/{id}/FoodItems
    /// <summary>
    /// Return a specific MenuFoodItemDTO when sending a request with a valid menu id.
    /// MenuFoodItemDTO contains Core Menu and a list of FoodItemDTO that the Menu is assocaited with.
    /// </summary>
    /// <param name="menuDTO"></param>
    /// <returns> Return a specific MenuFoodItemDTO with status 200 if success </returns>
    [HttpGet("{id}/FoodItems")]
    public async Task<ActionResult<MenuFoodItemDTO>> GetFoodItems(int id)
    {
        Menu menu;
        try // Try to get the menus foodItems from the db
        {
            menu = await GetMenuFoodItems(id);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);

        }
        if (menu != null) // if we have have a menu construct a DTO
        {
            var dto = MenuFoodItemDTO.BuildDTO(menu);
            if(dto != null) // if its null we don't have foodItems for this menus
            {
                return Ok(dto);
            }
            else
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }
        else
        {

            return StatusCode(StatusCodes.Status404NotFound);
        }
    }
    
    
    
    /// <summary>
    /// Return a specific MenuFoodBookingDTO when sending a request with a valid menu id.
    /// MenuFoodBookingDTO contains core Menu info and a list of FoodBookingDTO that the Menu is assocaited with.
    /// </summary>
    /// <param name="id"></param>
    /// <returns> Return a specific MenuFoodBookingDTO with status 200 if success </returns>
    [HttpGet("{id}/FoodBookings")]
    public async Task<ActionResult<MenuFoodBookingDTO>> GetFoodBookings(int id)
    {

        try
        {

            var menu = await _context.Menus
            .Include(m => m.FoodBookings)
            .FirstOrDefaultAsync(m => m.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }
            var menuDto = new MenuFoodBookingDTO
            {
                MenuId = menu.MenuId,
                MenuName = menu.MenuName,
                FoodBookings = menu.FoodBookings.Select(fb => new FoodBookingDTO
                {
                    FoodBookingId = fb.FoodBookingId,
                    ClientReferenceId = fb.ClientReferenceId,
                    NumberOfGuests = fb.NumberOfGuests,
                    MenuId = fb.MenuId,
                    FoodBookingDate = fb.FoodBookingDate
                }).ToList()
            };
            return menuDto;

        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }


    // PUT: api/Menus/5
    /// <summary>
    /// Update Menu
    /// </summary>
    /// <param name="id"></param>
    /// <param name="Menu"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMenu(int id, Menu menu)
    {
        if (id != menu.MenuId)
        {
            return BadRequest();
        }

        _context.Entry(menu).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MenuExists(id))
            {
                return NotFound();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        return NoContent();
    }

    /// <summary>
    /// Uses a list of FoodItems ids to either Delete items NOT in the input list OR Add items IN the input list
    /// </summary>
    [HttpPut("FoodItem/{MenuId}/Edit")]
    public async Task<IActionResult> EditFoodItems(int MenuId, [FromBody] MenuFoodItemEditModelDTO EditModel)
    {
        if (!ModelState.IsValid || MenuId != EditModel.MenuId)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }
        try
        {
            var menu = await _context.Menus.FindAsync(MenuId);
            if (menu == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var newFoodItems = EditModel.FoodItems.ToList();
            if ( AnyInputIsNotValid(newFoodItems))
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            // So what are this Trainers current Categories?
            var currentFoodItems = _context.MenuFoodItems.Where(m => m.MenuId == menu.MenuId).ToList();

            // Deletes items in the input list
            if (currentFoodItems.Count > 0)
            {
                var itemsToDelete = currentFoodItems.Where(item => !newFoodItems.Any(i => i == item.FoodItemId)).ToList();
                if (itemsToDelete.Any())
                {
                    _context.MenuFoodItems.RemoveRange(itemsToDelete);
                }
            }

            // Add items IN the input list
            foreach (var newItem in newFoodItems)
            {
                var exists = currentFoodItems.Any(e => e.FoodItemId.Equals(newItem) && e.MenuId == menu.MenuId);

                if (!exists)
                {
                    _context.MenuFoodItems.Add(new MenuFoodItem { MenuId = menu.MenuId, FoodItemId = newItem });
                }
            }

            _context.SaveChanges();
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        return Ok();
    }



    /// POST: api/Menus
    /// <summary>
    /// Add a Menu to the Collection
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<MenuDTO>> PostTrainer(MenuDTO menu)
    {

        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        Menu newMenu = new ()
        {
            MenuName = menu.MenuName,
        };

        try
        {
            _context.Menus.Add(newMenu);
            await _context.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }


        return CreatedAtAction("GetMenus", new { id = newMenu.MenuId }, newMenu);
    }

    /// DELETE: api/Menus/5
    /// <summary>
    /// Delete a Menu
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMenu(int id)
    {
        try
        {
            if (_context.Menus == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var menu = await _context.Menus
                .Include(m => m.MenuFoodItems)  // Include MenuFoodItems
                .Include(m => m.FoodBookings)  // Include FoodBookings
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }
            if(menu.FoodBookings.Count() > 0)
            {
                return BadRequest();
            }
            else
            {
                menu.MenuFoodItems = null;
                menu.FoodBookings = null;
                _context.Menus.Remove(menu);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }





    #region helperMethods
    private bool MenuExists(int id)
    {
        return _context.Menus.Any(e => e.MenuId == id);
    }
    private async Task<Menu> GetMenuFoodItems(int id)
    {
        return await _context.Menus.Include(f => f.MenuFoodItems).ThenInclude(f => f.FoodItem).SingleOrDefaultAsync(m => m.MenuId == id);
    }
    private bool AnyInputIsNotValid(List<int> inputIds)
    {
        return inputIds.Any(id => !_context.FoodItems.Any(e => e.FoodItemId == id));
    }
    #endregion
}

