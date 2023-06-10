using Microsoft.Extensions.DependencyInjection;

namespace Samples.ModularMonolith.Infrastructure.Events.Integrations
{
    public static class DependencyInjection
    {
        public static void AddIntegrationEvents(this IServiceCollection services)
        {
            services.AddScoped(typeof(IntegrationEventHookerInterceptor));
        }
    }
}
