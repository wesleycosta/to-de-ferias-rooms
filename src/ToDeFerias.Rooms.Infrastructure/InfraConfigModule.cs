using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDeFerias.Rooms.Domain.Interfaces.Repositories;
using ToDeFerias.Rooms.Infrastructure.Data;
using ToDeFerias.Rooms.Infrastructure.Data.Repositories;

namespace ToDeFerias.Rooms.Infrastructure;

public static class InfraConfigModule
{
    public static IServiceCollection AddInfraConfiguration(this IServiceCollection services, IConfiguration configuration) =>
       services.AddContext(configuration)
               .AddRepositories();

    private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration) =>
        //services.AddDbContext<RoomsContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddDbContext<RoomsContext>(options => options.UseInMemoryDatabase("bookings"));

    private static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IRoomRepository, RoomRepository>()
                .AddScoped<IRoomTypeRepository, RoomTypeRepository>();

    public static IApplicationBuilder ApplyMigrate(this IApplicationBuilder app)
    {
        try
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetService<RoomsContext>();
            ArgumentNullException.ThrowIfNull(context);

            if (context.Database.ProviderName.Contains("InMemory"))
                return app;
            
            var pendingMigrations = context.Database.GetPendingMigrations();
            context.Database.Migrate();
        }
        catch
        {
            throw;
        }

        return app;
    }
}
