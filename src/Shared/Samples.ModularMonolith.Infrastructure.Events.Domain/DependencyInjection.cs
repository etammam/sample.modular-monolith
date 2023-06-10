using Microsoft.Extensions.DependencyInjection;

namespace Samples.ModularMonolith.Infrastructure.Events.Domain
{
    public static class DependencyInjection
    {
        public static void AddDomainEvents(this IServiceCollection services)
        {
            services.AddScoped(typeof(DomainEventHookerInterceptor));
        }
    }
}
