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
    public async Task<ActionResult<RoomModel>> Post([FromBody] RoomDto roomDto)
    {
        if (roomDto == null)
        {
            return BadRequest(new { message = "Room data cannot be null." });
        }

        var newRoom = new RoomModel
        {
            RoomNumber = roomDto.RoomNumber,
            RoomType = roomDto.RoomType,
            IsVacant = roomDto.IsVacant,
            Price = roomDto.Price,
            NeedCleaning = roomDto.NeedCleaning
        };

        _context.Rooms.Add(newRoom);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = newRoom.RoomID }, newRoom);
    }

    // PUT api/room/{roomNumber}
    [HttpPut("{roomNumber}")]
    public async Task<IActionResult> UpdateRoomByNumber(string roomNumber, [FromBody] RoomDto roomDto)
    {
        if (roomDto == null)
            return BadRequest("Room data cannot be null.");

        if (roomNumber != roomDto.RoomNumber)
            return BadRequest("Rumsnumret stämmer inte.");

        var existingRoom = await _context.Rooms
            .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);

        if (existingRoom == null)
            return NotFound("Rummet hittades ej.");

        // Uppdatera endast om giltiga värden skickas
        if (!string.IsNullOrEmpty(roomDto.RoomType))
        {
            existingRoom.RoomType = roomDto.RoomType;
        }

        existingRoom.IsVacant = roomDto.IsVacant;

        if (roomDto.Price >= 0) // Tillåt även 0 som giltigt värde
        {
            existingRoom.Price = roomDto.Price;
        }

        existingRoom.NeedCleaning = roomDto.NeedCleaning;

        try
        {
            await _context.SaveChangesAsync();
            return Ok(existingRoom);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ett fel uppstod: {ex.Message}");
        }
    }

    // DELETE api/room/{roomNumber} 
    [HttpDelete("{roomNumber}")]
    public async Task<IActionResult> DeleteRoomByNumber(string roomNumber)
    {
        var existingRoom = await _context.Rooms
            .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);
        if (existingRoom == null)
            return NotFound("Rummet hittades ej.");

        _context.Rooms.Remove(existingRoom);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}