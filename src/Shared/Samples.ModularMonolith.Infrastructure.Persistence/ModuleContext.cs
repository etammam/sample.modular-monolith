using Microsoft.EntityFrameworkCore;

namespace Samples.ModularMonolith.Infrastructure.Persistence
{
    public class ModuleContext : DbContext, IGenericContext
    {
        public ModuleContext(DbContextOptions<ModuleContext> options)
            : base(options)
        {
        }
    }
}
