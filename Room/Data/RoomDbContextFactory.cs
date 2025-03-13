using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Room.Data
{
    public class RoomDbContextFactory : IDesignTimeDbContextFactory<RoomDbContext>
    {
        public RoomDbContext CreateDbContext(string[] args)
        {
            // 🛠 Lösning: Hantera specialtecken i sökvägen korrekt
            string configDirectory = @"C:\Users\phosf\OneDrive - Högskolan Väst\Documents\sysArkt_SOS100\SOAgrpAPI\Rooms\Room";
            string configFile = "appsettings.json";
            string configPath = Path.Combine(configDirectory, configFile);

            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException($"⚠️ Konfigurationsfilen hittades inte på sökvägen: {configPath}");
            }

            var config = new ConfigurationBuilder()
                .SetBasePath(configDirectory)
                .AddJsonFile(configFile, optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<RoomDbContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            return new RoomDbContext(optionsBuilder.Options);
        }
    }
}