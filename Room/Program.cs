using Microsoft.EntityFrameworkCore;
using Room.Data; // Se till att rätt namespace importeras

var builder = WebApplication.CreateBuilder(args);

// Ladda in appsettings.json
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Lägg till tjänster i DI-containern
builder.Services.AddControllers();
builder.Services.AddAuthorization(); // ? Fix: Registrerar auktoriseringstjänsten
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Lägg till ApplicationDbContext (hanterar användare och säkerhet)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Lägg till RoomDbContext (hanterar hotellrum)
builder.Services.AddDbContext<RoomDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RoomDatabase")));

var app = builder.Build();

// Konfigurera Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Room API v1");
        c.RoutePrefix = string.Empty; // Swagger visas direkt på roten
    });
}

app.UseHttpsRedirection();
app.UseAuthorization(); // OBS: Nu fungerar detta eftersom AddAuthorization() har lagts till!
app.MapControllers();
app.Run();