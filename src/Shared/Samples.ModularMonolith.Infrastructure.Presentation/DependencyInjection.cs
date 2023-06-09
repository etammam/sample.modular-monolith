using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.ModularMonolith.Infrastructure.Presentation.Configurations;
using Samples.ModularMonolith.Infrastructure.Presentation.InboundNotifications;
using Samples.ModularMonolith.Infrastructure.Presentation.Middleware.Exceptions;

namespace Samples.ModularMonolith.Infrastructure.Presentation
{
    public static class DependencyInjection
    {
        public static void AddPresentation(this IServiceCollection services)
        {
            services.AddSingleton(typeof(INotificationContext<>), typeof(NotificationContext<>));
            services.AddSingleton<InboundNotificationConnectorsMap>();

            services.Configure<FormOptions>(options =>
            {
                options.BufferBody = true;
                options.BufferBodyLengthLimit = long.MaxValue;
                options.KeyLengthLimit = int.MaxValue;
                options.ValueLengthLimit = int.MaxValue;
            });
        }

        public static void AddExceptionHandler(this IServiceCollection services, IConfiguration configurations,
            string exceptionConfigurationSection = "Exception")
        {
            services.Configure<ExceptionConfiguration>(configurations.GetSection(exceptionConfigurationSection));
            services.AddSingleton<ExceptionMiddleware>();
        }
    }
}
