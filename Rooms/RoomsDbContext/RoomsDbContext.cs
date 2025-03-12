using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Rooms.RoomsDbContext
{
    public class RoomsDbContext : DbContext
    {
        public RoomsDbContext(DbContextOptions<RoomsDbContext> options) : base(options) { }

        public DbSet<RoomsDbContext> YourEntities { get; set; }
    }
}
