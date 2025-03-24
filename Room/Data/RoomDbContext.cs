using Microsoft.EntityFrameworkCore;
using Room.Models;

namespace Room.Data
{
    public class RoomDbContext : DbContext
    {
        public RoomDbContext(DbContextOptions<RoomDbContext> options) : base(options) { }

        public DbSet<RoomModel> Rooms { get; set; }
        public DbSet<ApiUsageLog> ApiUsageLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomModel>()
                .HasIndex(r => r.RoomNumber)
                .IsUnique();
        }


    }
}