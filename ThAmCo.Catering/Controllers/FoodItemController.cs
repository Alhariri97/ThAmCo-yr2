using System.Linq;

namespace ThAmCo.Catering.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodItemsController : ControllerBase
{
    private readonly DataContext _context;

    public FoodItemsController(DataContext context)
    {
        _context = context;
    }

    /// GET api/FoodItem
    /// <summary>
    /// Returns a list of FoodItemDTOs
    /// </summary>
    /// <returns> a list of FoodItemDTOs with status 200 if success </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodItemDTO>>> GetFoodItems()
    {
        try
        {
            var foodItmes = await _context.FoodItems.OrderByDescending(fi =>fi.FoodItemId).ToListAsync();
            List<FoodItemDTO> dto = foodItmes.Select(c => new FoodItemDTO
            {
                Name = c.Name,
                FoodItemId = c.FoodItemId,
                Description = c.Description,
                UnitPrice = c.UnitPrice,
            }).ToList();
            return Ok(dto);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unable to provide FoodItems at this time");
        }
    }

    ///GET api/FoodItem/{id} => api/FoodItem/1
    /// <summary>
    /// Returns a specific FoodItemDTO 
    /// </summary>
    /// <param name="id"></param>
    /// <returns> a specific FoodItemDTO with status 200 if success  </returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<FoodItemDTO>> GetFoodItem(int id)
    {
        try
        {
            var foodItem = await _context.FoodItems.FindAsync(id);

            if (foodItem == null)
            {
                return NotFound();
            }
            FoodItemDTO foodItemDTO = new FoodItemDTO().CreateFoodItemDTO(foodItem);

            //{
            //    Name = foodItem.Name,
            //    FoodItemId = foodItem.FoodItemId,
            //    Description = foodItem.Description,
            //    UnitPrice = foodItem.UnitPrice,
            //};

            return Ok(foodItemDTO);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unable to provide FoodItem at this time");
        }
    }

    /// POST api/FoodItem
    /// <summary>
    /// Send a Post request with FooditemDTO to add a new fooditem.
    /// </summary>
    /// <param name="foodItem"></param>
    /// <returns> Returns the new created FooditemDTO With status 201 if success </returns>
    [HttpPost]
    public async Task<ActionResult<FoodItemDTO>> PostFoodItem(FoodItemCreateDTO foodItem)
    {
        // Check if the model is valid
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        //  create it and Add it.
        try
        {
            FoodItem newFoodItem = new()
            {
                Name = foodItem.Name,
                Description = foodItem.Description,
                UnitPrice = foodItem.UnitPrice,
            };
            _context.FoodItems.Add(newFoodItem);
            await _context.SaveChangesAsync();

            // Create a DTO for the newly created food item
            FoodItemDTO newFoodItemDTO = new FoodItemDTO().CreateFoodItemDTO(newFoodItem);

            //{
            //    FoodItemId = newFoodItem.FoodItemId,
            //    Name = newFoodItem.Name,
            //    Description = newFoodItem.Description,
            //    UnitPrice = newFoodItem.UnitPrice,
            //};

            // Return the DTO with a 201 status
            return CreatedAtAction(nameof(GetFoodItem), new { id = newFoodItemDTO.FoodItemId }, newFoodItemDTO);

        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }


    //PUT api/FoodItem/{id} 
    /// <summary>
    /// Send a Put request with FooditemDTO to Edit an existing fooditem.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="foodItem"></param>
    /// <returns> the Edited fooditemDTO with 200 if success </returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<FoodItemDTO>> PutFoodItem(int id, FoodItemDTO foodItem)
    {
        if (id != foodItem.FoodItemId || !ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        try
        {
            var oldFoodItem = await _context.FoodItems.FindAsync(id);
            if (oldFoodItem == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            // Check if a food item with the same name already exists

            oldFoodItem.UnitPrice = foodItem.UnitPrice;
            oldFoodItem.Name = foodItem.Name;
            oldFoodItem.Description = foodItem.Description;
            _context.Entry(oldFoodItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            FoodItemDTO newFoodItemDTO = new FoodItemDTO().CreateFoodItemDTO(oldFoodItem);
            //{
            //    FoodItemId = oldFoodItem.FoodItemId,
            //    Name = oldFoodItem.Name,
            //    Description = oldFoodItem.Description,
            //    UnitPrice = oldFoodItem.UnitPrice,
            //};
            return CreatedAtAction(nameof(GetFoodItem), new { id = newFoodItemDTO.FoodItemId }, newFoodItemDTO);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);

        }
    }

    /// DELETE api/fooditem/{id}
    /// <summary>
    /// Send a Delete request with the id of the foodItem to delete it.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content wit h 204 status code if success </returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFoodItem(int id)
    {
        try
        {

            //var foodItem = await _context.FoodItems.Include(m=>m.MenuFoodItems).ThenInclude(m => m.MenuId).FirstOrDefaultAsync(fi => fi.FoodItemId == id);

            //if (foodItem == null)
            //{
            //    return StatusCode(StatusCodes.Status404NotFound);
            //}

            // Retrieve the FoodItem with its associated MenuFoodItems
            var foodItem = await _context.FoodItems.FindAsync(id);

            if (foodItem == null)
            {
                return NotFound();
            }

            // Explicitly load the MenuFoodItems
            await _context.Entry(foodItem)
                .Collection(fi => fi.MenuFoodItems)
                .LoadAsync();
            if (foodItem == null)
            {
                return NotFound();
            }

            // Remove the FoodItem from all associated MenuFoodItems
            foreach (var menuFoodItem in foodItem.MenuFoodItems.ToList())
            {
                _context.MenuFoodItems.Remove(menuFoodItem);
            }

            _context.FoodItems.Remove(foodItem);
            await _context.SaveChangesAsync();


            return StatusCode(StatusCodes.Status204NoContent);
            //// Save changes to the database
            //await _context.SaveChangesAsync();

            //return Ok();



        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);

        }
    }

    private bool FoodItemExists(string name)
    {
        return _context.FoodItems.Any(e => e.Name == name);
    }
}