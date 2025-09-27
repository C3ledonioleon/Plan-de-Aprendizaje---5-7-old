using Proyecto.Repositories;
using Proyecto.Repositories.Contracts;
using Proyecto.Services;
using Proyecto.Services.Contracts;

public static class StartupExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IClienteService, ClienteService>();

        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IClienteRepository, ClienteRepository>();

        return services;
    }

}