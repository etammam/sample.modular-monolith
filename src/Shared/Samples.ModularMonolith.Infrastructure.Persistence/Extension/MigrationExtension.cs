using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Extension
{
    public static class MigrationExtension
    {
        public static IApplicationBuilder UseAutomaticMigration<TContext>(this IApplicationBuilder appBuilder)
            where TContext : DbContext
        {
            using var scope = appBuilder.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

            scope?.ServiceProvider.GetRequiredService<TContext>().Database.Migrate();

            return appBuilder;
        }
    }
}
