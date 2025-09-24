using Proyecto.Services;
using Proyecto.Repositories.Contracts;
using Proyecto.Interfaces;
using Proyecto.Controllers;
using Proyecto.Repositories.Contratcs;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSingleton<QRService>();
// Las Interfaz y los repository 
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IEntradaRepository,EntradaRepository >();
builder.Services.AddTransient<IEventoRepository, EventoRepository>();
builder.Services.AddTransient<IFuncionRepository, FuncionRepository>();
builder.Services.AddTransient<IOrdenRepository, OrdenRepository>();
builder.Services.AddTransient<ISectorRepository, SectorRepository>();
builder.Services.AddTransient<ILocalRepository, LocalRepository>();
builder.Services.AddTransient<ITarifaRepository, TarifaRepository>();


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

