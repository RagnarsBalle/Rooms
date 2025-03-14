using Microsoft.EntityFrameworkCore;
using Room.Models;

namespace Room.Data
{
    public class RoomDbContext : DbContext
    {
        public RoomDbContext(DbContextOptions<RoomDbContext> options) : base(options) { }

        public DbSet<RoomModel> Rooms { get; set; }
    }
}