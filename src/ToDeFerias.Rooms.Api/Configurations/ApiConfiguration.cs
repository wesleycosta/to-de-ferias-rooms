using ToDeFerias.Rooms.Infrastructure;

namespace ToDeFerias.Rooms.Api.Configurations;

internal static class ApiConfiguration
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddInfraConfiguration(configuration);

        return services;
    }
}
