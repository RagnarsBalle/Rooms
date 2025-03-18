using Microsoft.EntityFrameworkCore;
using Room.Data;
using Microsoft.Extensions.Configuration;
using Scalar.AspNetCore;
using Microsoft.AspNetCore.OpenApi; // Lägg till OpenAPI

var builder = WebApplication.CreateBuilder(args);

// Lägg till tjänster i DI-containern
builder.Services.AddControllers();
builder.Services.AddAuthorization();

// Lägg till RoomDbContext med anslutningssträng
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       Environment.GetEnvironmentVariable("CONNECTION_STRING");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Anslutningssträngen 'DefaultConnection' saknas i appsettings.json.");
}

builder.Services.AddDbContext<RoomDbContext>(options =>
    options.UseSqlServer(connectionString));

// Lägg till OpenAPI för att generera dokumentation
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

// Aktivera OpenAPI-mellanvara för att skapa dokumentationen
app.MapOpenApi();

// Aktivera Scalar UI på /docs
app.MapScalarApiReference(options =>
{
    options.Title = "Room API Dokumentation";
    options.Theme = ScalarTheme.Mars; // Du kan välja ett annat tema
    options.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
});

app.MapControllers();
app.Run();
