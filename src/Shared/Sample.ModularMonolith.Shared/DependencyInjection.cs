using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.ModularMonolith.Shared.Bones.Background;
using Sample.ModularMonolith.Shared.Bones.Database;
using Samples.ModularMonolith.Infrastructure.Events.Domain;
using Samples.ModularMonolith.Infrastructure.Events.Integrations;
using Samples.ModularMonolith.Infrastructure.Persistence;
using Samples.ModularMonolith.Infrastructure.Presentation;
using Samples.ModularMonolith.Services.Generic;

namespace Sample.ModularMonolith.Shared
{
    public static class DependencyInjection
    {
        public static void AddShared(this IServiceCollection services, IConfiguration configurations)
        {
            services.AddPresentation();
            services.AddDomainEvents();
            services.AddIntegrationEvents();
            services.AddPersistence();
            services.AddDatabase(configurations);
            services.AddExceptionHandler(configurations);
            services.AddGenericService();
            services.AddBackground(configurations);
        }

        public static void AddCommunicationService(this IServiceCollection services, IConfiguration configurations)
        {
        }

        public static void UseShared(this WebApplication app, IServiceCollection services)
        {
            app.UseBackground(services);
        }
    }
}