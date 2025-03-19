using Microsoft.EntityFrameworkCore;
using Room.Data;
using Microsoft.Extensions.Configuration;
using Scalar.AspNetCore;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthorization();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       Environment.GetEnvironmentVariable("CONNECTION_STRING");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Anslutningssträngen 'DefaultConnection' saknas i appsettings.json.");
}

builder.Services.AddDbContext<RoomDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UsePathBase("/RoomAPI");


// Aktivera OpenAPI-mellanvara för att skapa dokumentationen
app.MapOpenApi();

// Aktivera Scalar UI även i produktion för testning av CRUD
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.MapScalarApiReference(options =>
    {
        options.Title = "Room API Dokumentation";
        options.Theme = ScalarTheme.Mars;
        options.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
    });
}

app.MapControllers();
app.Run();
