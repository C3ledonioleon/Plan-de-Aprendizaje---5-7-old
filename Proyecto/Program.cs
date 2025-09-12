using Proyecto.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSingleton<QRService>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var urlBase = "http://localhost:5296"; // O el puerto que .NET indique
Console.WriteLine($"Tu endpoint de QR está disponible en: {urlBase}/api/entradas/123/qr");

app.Run();

