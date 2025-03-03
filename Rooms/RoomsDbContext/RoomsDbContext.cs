using System.Collections.Generic;

namespace Rooms.RoomsDbContext
{
    public class RoomsDbContext : DbContext
    {
        public RoomsDbContext(DbContextOptions<RoomsDbContext> options) : base(options) { }

        public DbSet<YourEntity> YourEntities { get; set; }
    }
}
