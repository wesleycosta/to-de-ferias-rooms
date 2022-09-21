using Microsoft.Extensions.DependencyInjection;

namespace ToDeFerias.Core.Notifier;

public static class NotifierIoC
{
    public static IServiceCollection AddNotifications(this IServiceCollection services) =>
      services.AddScoped<INotifier, Notifier>();
}
