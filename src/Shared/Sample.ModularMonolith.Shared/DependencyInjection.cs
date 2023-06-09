using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.ModularMonolith.Shared.Bones.Background;
using Samples.ModularMonolith.Communications.Abstractions;
using Samples.ModularMonolith.Communications.Clients;
using Samples.ModularMonolith.Infrastructure.Presentation;
using Samples.ModularMonolith.Services.Generic;

namespace Sample.ModularMonolith.Shared
{
    public static class DependencyInjection
    {
        public static void AddShared(this IServiceCollection services, IConfiguration configurations)
        {
            services.AddCommunications();
            services.AddCommunicationsClient();
            services.AddPresentation();
            services.AddExceptionHandler(configurations);
            services.AddGenericService();

            services.AddBackground(configurations);
        }

        public static void UseShared(this WebApplication app, IServiceCollection services)
        {
            app.UseBackground(services);
        }
    }
}