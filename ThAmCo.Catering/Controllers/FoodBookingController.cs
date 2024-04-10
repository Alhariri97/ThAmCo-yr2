using Microsoft.EntityFrameworkCore;
/// <summary>
/// Done
/// A controller to manage FoodBookings
/// </summary>
namespace ThAmCo.Catering.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodBookingsController : ControllerBase
{
    private readonly DataContext _context;

    public FoodBookingsController(DataContext context)
    {
        _context = context;
    }

    /// GET: api/FoodBooking
    /// <summary>
    /// Get All FoodBookings as a list of FoodBookingDTO
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FoodBookingDTO>>> GetFoodBookings()
    {
        if (_context.FoodBookings == null)
        {
            return NotFound();
        }
        var foodBookings = await _context.FoodBookings
            .OrderByDescending(fb =>fb.FoodBookingDate)
            .ToListAsync();

        var dto = foodBookings.Select(s => new FoodBookingDTO().BuildDTO(s)).ToList();

        return Ok(dto);
    }



    // GET: api/FoodBooking/5
    /// <summary>
    /// Get a FoodBookingDTO by foodBooking Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<FoodBookingDTO>> GetFoodBooking(int id)
    {
        if (_context.FoodBookings == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        var foodBooking = await _context.FoodBookings.FindAsync(id);

        if (foodBooking == null)
        {
            return NotFound();
        }

        var dto = new FoodBookingDTO().BuildDTO(foodBooking);

        return dto;
    }




    /// <summary>
    /// Modify an existing FoodBooking so that the booking refrence is null
    /// </summary>
    [HttpPut("{foodBookingId}/cancel")]
    public async Task<IActionResult> CancelFoodBooking(int foodBookingId)
    {

        var foodBookings = await _context.FoodBookings.FindAsync(foodBookingId);

        if (foodBookings == null)
        {
            return NotFound();
        }

        if(foodBookings.ClientReferenceId ==null)
        {
            return BadRequest();
        }

        try
        {
            foodBookings.ClientReferenceId = null;

            await _context.SaveChangesAsync();
            return Ok(); 
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }



    /// <summary>
    ///  Update foodBookingId and MenuId for a foodBooking, if Menu is available for that foodBooking
    /// </summary>
    [HttpPut("{foodBookingId}/edit")]
    public async Task<IActionResult> EditFoodBooking(int foodBookingId, FoodBookingDTO newFoodBooking)
    {
        if (foodBookingId != newFoodBooking.FoodBookingId)
        {
            return BadRequest();
        }

        var oldFoodBooking = await _context.FoodBookings.FindAsync(foodBookingId);

        if (oldFoodBooking == null)
        {
            return NotFound();
        }

        var menu = await _context.Menus.FindAsync(newFoodBooking.MenuId);
        if (menu == null)
        {
            return BadRequest("Menu does not exist");
        }

        oldFoodBooking.ClientReferenceId = newFoodBooking.ClientReferenceId;
        oldFoodBooking.MenuId = newFoodBooking.MenuId;
        oldFoodBooking.FoodBookingDate = newFoodBooking.FoodBookingDate;
        oldFoodBooking.NumberOfGuests  = newFoodBooking.NumberOfGuests;

        _context.Entry(oldFoodBooking).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FoodBookingExists(foodBookingId))
            {
                return NotFound();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        FoodBookingDTO foodBookingDTO = new FoodBookingDTO().BuildDTO(oldFoodBooking);

        return Ok(foodBookingDTO); //https://stackoverflow.com/questions/2342579/http-status-code-for-update-and-delete#:~:text=If%20an%20existing%20resource%20is%20modified%2C%20either%20the%20200%20(OK)
    }



    // POST: api/Sessions
    /// <summary>
    /// Add a FoodBooking if the Menu is available for that foodBooking
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<FoodBookingDTO>> NewFoodBookinng(FoodBookingDTO foodBooking)
    {
        if (_context.FoodBookings == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }



        var menu = await _context.Menus.FindAsync(foodBooking.MenuId);
        if (menu == null)
        {
            return BadRequest("Menu does not exist");
        }
        var foodBookings = _context.FoodBookings.ToList();

        bool noneHaveClientReferenceId = foodBookings.Any(fb => fb.ClientReferenceId == foodBooking.ClientReferenceId);

        if (noneHaveClientReferenceId)
        {
            return BadRequest("This Event already has a booking");

        }
        FoodBooking newFoodBooking = new()
        {
            ClientReferenceId = foodBooking.ClientReferenceId, 
            NumberOfGuests = foodBooking.NumberOfGuests,
            MenuId = foodBooking.MenuId,
            FoodBookingDate = foodBooking.FoodBookingDate,
        };

        try
        {
            _context.FoodBookings.Add(newFoodBooking);
            await _context.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        /// Returns the foodBooking id as it said in the requirements file:
        /// •	Book, edit and cancel Food for an Event - see the ERD above for details.
        /// The service should return the FoodBookingId as confirmation of the booking; 
        FoodBookingDTO createdFoodBookingDTO = new FoodBookingDTO().BuildDTO(newFoodBooking); 

        return new ObjectResult(createdFoodBookingDTO.FoodBookingId) { StatusCode = StatusCodes.Status201Created };



    }


    // DELETE: api/FoodBooking/5
    /// <summary>
    /// Delete a FoodBooking with NO BookingId
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSession(int id)
    {
        if (_context.FoodBookings == null)
        {
            return NotFound();
        }
        var foodBooking = await _context.FoodBookings.FindAsync(id);
        if (foodBooking == null)
        {
            return NotFound();
        }
        if (foodBooking.ClientReferenceId != null)
        {
            return StatusCode(StatusCodes.Status405MethodNotAllowed);
        }

        try
        {
            _context.FoodBookings.Remove(foodBooking);
            await _context.SaveChangesAsync();
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return StatusCode(StatusCodes.Status204NoContent);
    }


    private bool FoodBookingExists(int id)
    {
        return (_context.FoodBookings?.Any(e => e.FoodBookingId == id)).GetValueOrDefault();
    }



}

