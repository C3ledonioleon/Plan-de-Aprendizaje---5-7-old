using Proyecto.Repositories;
using Proyecto.Repositories.Contracts;
using Proyecto.Services;
using Proyecto.Services.Contracts;

public static class StartupExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IEntradaService, EntradaService>();
        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IClienteRepository, ClienteRepository>();

        services.AddTransient<IEntradaRepository, EntradaRepository>();

        services.AddTransient<IEventoRepository, EventoRepository>();

        services.AddTransient<IFuncionRepository, FuncionRepository>();

        services.AddTransient<ILocalRepository, LocalRepository>();

        services.AddTransient<IOrdenRepository, OrdenRepository>();

        services.AddTransient<ISectorRepository, SectorRepository>();

        services.AddTransient<ITarifaRepository, TarifaRepository>();

        return services;
    }

}