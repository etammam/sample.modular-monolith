using Microsoft.Extensions.DependencyInjection;
using Samples.ModularMonolith.Services.Generic.Clocking;
using Samples.ModularMonolith.Services.Generic.CurrentUser;
using Samples.ModularMonolith.Services.Generic.Serialization;

namespace Samples.ModularMonolith.Services.Generic
{
    public static class DependencyInjection
    {
        public static void AddGenericService(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ISerializationService, SerializationService>();
            services.AddTransient<IClockService, ClockService>();
        }
    }
}
