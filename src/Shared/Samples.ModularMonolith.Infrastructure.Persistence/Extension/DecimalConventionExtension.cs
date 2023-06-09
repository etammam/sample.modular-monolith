using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Extension
{
    public static class DecimalConventionExtension
    {
        public static void UseDecimalConvention(this ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties())
                         .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18, 2)");
            }
        }
    }
}
