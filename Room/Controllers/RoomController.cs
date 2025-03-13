using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Room.Models;
using Room.Data;


[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly RoomDbContext _context;

    public RoomController(RoomDbContext context)
    {
        _context = context;
    }

    // GET: /api/room
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoomModel>>> Get()
    {
        var rooms = await _context.Rooms.ToListAsync();
        return Ok(rooms);
    }

    // POST: /api/room
    [HttpPost]
    public async Task<ActionResult<Room.Models.RoomModel>> Post([FromBody] Room.Models.RoomModel data)
    {
        if (data == null)
        {
            return BadRequest(new { message = "Room data cannot be null." });
        }

        _context.Rooms.Add(data);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = data.RoomID }, data);
    }
}