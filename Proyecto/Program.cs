using Proyecto.Services;
using Proyecto.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSingleton<QRService>();
builder.Services.AddSingleton<ClienteRepository>();

// Registrar ClienteRepository con la cadena de conexión
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ClienteRepository>(provider =>
    new ClienteRepository(
        builder.Configuration
    )
);

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SVE API V1");
        c.RoutePrefix = ""; // Así Swagger UI queda en la raíz: http://localhost:5000/
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var urlBase = "http://localhost:5296"; // O el puerto que .NET indique
Console.WriteLine($"Tu endpoint de QR está disponible en: {urlBase}/api/entradas/123/qr");

app.Run();

