using MediatR.NotificationPublishers;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.ModularMonolith.Infrastructure.Presentation.Behaviors;
using Samples.ModularMonolith.Infrastructure.Presentation.Configurations;
using Samples.ModularMonolith.Infrastructure.Presentation.InboundNotifications;
using Samples.ModularMonolith.Infrastructure.Presentation.Middleware.Exceptions;
using Samples.ModularMonolith.Infrastructure.Presentation.Swagger;
using System.Diagnostics;

namespace Samples.ModularMonolith.Infrastructure.Presentation
{
    public static class DependencyInjection
    {
        public static void AddPresentation(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwagger();
            services.AddSingleton(typeof(INotificationContext<>), typeof(NotificationContext<>));
            services.AddSingleton<InboundNotificationConnectorsMap>();

            services.Configure<FormOptions>(options =>
            {
                options.BufferBody = true;
                options.BufferBodyLengthLimit = long.MaxValue;
                options.KeyLengthLimit = int.MaxValue;
                options.ValueLengthLimit = int.MaxValue;
            });

            services.AddTransient<Stopwatch>();

            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
            // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblyContaining<AssemblyPointer>();

                configuration.AddOpenBehavior(
                    openBehaviorType: typeof(PerformanceBehavior<,>),
                    serviceLifetime: ServiceLifetime.Transient);

                configuration.AddOpenBehavior(
                    openBehaviorType: typeof(ValidationBehavior<,>),
                    serviceLifetime: ServiceLifetime.Transient);

                configuration.NotificationPublisher = new TaskWhenAllPublisher();
            });

            services.AddFluentValidationRulesToSwagger();
            services.AddDateOnlyTimeOnlyStringConverters();
        }

        public static void AddExceptionHandler(this IServiceCollection services, IConfiguration configurations,
            string exceptionConfigurationSection = "Exception")
        {
            services.Configure<ExceptionConfiguration>(configurations.GetSection(exceptionConfigurationSection));
            services.AddSingleton<ExceptionMiddleware>();
        }
    }
}
