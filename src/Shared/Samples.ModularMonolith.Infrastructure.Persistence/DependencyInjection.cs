using Microsoft.Extensions.DependencyInjection;
using Samples.ModularMonolith.Infrastructure.Persistence.Interceptors;

namespace Samples.ModularMonolith.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddAutoMapper(options => options.AddMaps(typeof(AssemblyPointer).Assembly));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(AuditInterceptor));
        }
    }
}
