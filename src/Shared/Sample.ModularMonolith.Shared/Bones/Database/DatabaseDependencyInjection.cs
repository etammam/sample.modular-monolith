using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Samples.ModularMonolith.Infrastructure.Events.Domain;
using Samples.ModularMonolith.Infrastructure.Events.Integrations;
using Samples.ModularMonolith.Infrastructure.Persistence;
using Samples.ModularMonolith.Infrastructure.Persistence.Interceptors;
using System;

namespace Sample.ModularMonolith.Shared.Bones.Database
{
    internal static class DatabaseDependencyInjection
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configurations,
            string databaseConnectionName = "default", bool useDomainEvents = true, bool useIntegrationEvents = true)
        {
            var connectionString = configurations.GetConnectionString(databaseConnectionName);
            ArgumentException.ThrowIfNullOrEmpty(connectionString, "database connection string is required");

            services.AddDbContext<IGenericContext, ModuleContext>((serviceProviderContext, options) =>
            {
                options.UseSqlServer(connectionString, builder =>
                {
                    builder.EnableRetryOnFailure(5);
                    builder.ExecutionStrategy(dependencies => new SqlServerRetryingExecutionStrategy(dependencies, 3));
                });

                var serviceProviderScopedContext = serviceProviderContext.CreateScope().ServiceProvider;

                if (useDomainEvents)
                {
                    var domainEventHookInterceptor = serviceProviderScopedContext.GetRequiredService<DomainEventHookerInterceptor>();
                    options.AddInterceptors(domainEventHookInterceptor);
                }

                if (useIntegrationEvents)
                {
                    var integrationEventHookInterceptor = serviceProviderScopedContext.GetRequiredService<IntegrationEventHookerInterceptor>();
                    options.AddInterceptors(integrationEventHookInterceptor);
                }

                var auditInterceptor = serviceProviderScopedContext.GetService<AuditInterceptor>();
                options.AddInterceptors(auditInterceptor);
            });
        }
    }
}
