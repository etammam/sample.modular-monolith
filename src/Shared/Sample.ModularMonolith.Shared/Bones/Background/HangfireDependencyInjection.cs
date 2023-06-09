using Hangfire;
using Hangfire.Console;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.Heartbeat;
using Hangfire.Heartbeat.Server;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;

namespace Sample.ModularMonolith.Shared.Bones.Background
{
    internal static class HangfireDependencyInjection
    {
        public static void AddBackground(this IServiceCollection services,
            IConfiguration configurations,
            string connectionStringName = "default",
            string configurationSectionName = "Hangfire")
        {
            var connectionString = configurations.GetConnectionString(connectionStringName);

            services.Configure<HangfireConfigurations>(configurations.GetSection(configurationSectionName));

            var hangfireConfiguration =
                services.BuildServiceProvider().GetService<IOptions<HangfireConfigurations>>()!.Value;

            services.AddHangfire(options =>
            {
                options.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
                options.UseSimpleAssemblyNameTypeSerializer();
                options.UseRecommendedSerializerSettings(c =>
                {
                    c.TypeNameHandling = TypeNameHandling.All;
                    c.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

                options.UseSqlServerStorage(connectionString, new SqlServerStorageOptions
                {
                    SchemaName = hangfireConfiguration.SchemaName,
                });
                options.UseConsole();
                options.UseHeartbeatPage(TimeSpan.FromSeconds(hangfireConfiguration.ProcessMonitorCheckingIntervalInSeconds));
            });

            if (!string.IsNullOrEmpty(configurations.GetConnectionString(connectionStringName)))
            {
                var sqlStorage = new SqlServerStorage(connectionString, options: new SqlServerStorageOptions()
                {
                    SchemaName = hangfireConfiguration.SchemaName,
                    PrepareSchemaIfNecessary = true
                });
                JobStorage.Current = sqlStorage;

                var processors = new[]
                {
                    new ProcessMonitor(TimeSpan.FromSeconds(hangfireConfiguration.ProcessMonitorCheckingIntervalInSeconds))
                };

                services.AddHangfireServer(
                    optionsAction: (_, options) => options.Queues = hangfireConfiguration.Queues,
                    storage: sqlStorage,
                    additionalProcesses: processors);
            }
        }

        public static void UseBackground(this WebApplication app, IServiceCollection services,
            string configurationSectionName = "Hangfire")
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>()
                                ?? throw new ArgumentException(nameof(IConfiguration));

            var hangfireConfiguration = new HangfireConfigurations();
            configuration.Bind(configurationSectionName, hangfireConfiguration);

            app.UseHangfireDashboard(hangfireConfiguration.Url, new DashboardOptions
            {
                DashboardTitle = hangfireConfiguration.Title,
                Authorization = new[]
                {
                    new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                    {
                        RequireSsl = false,
                        SslRedirect = false,
                        LoginCaseSensitive = true,
                        Users = new[]
                        {
                            new BasicAuthAuthorizationUser
                            {
                                Login = hangfireConfiguration.Username,
                                PasswordClear = hangfireConfiguration.Password
                            }
                        }
                    })
                }
            });
        }
    }
}
