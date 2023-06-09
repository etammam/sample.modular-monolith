using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Samples.ModularMonolith.Services.Generic.Clocking;
using Samples.ModularMonolith.Services.Generic.CurrentUser;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Interceptors
{
    internal class AuditInterceptor : SaveChangesInterceptor
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IClockService _clockService;

        public AuditInterceptor(ICurrentUserService currentUserService, IClockService clockService)
        {
            _currentUserService = currentUserService;
            _clockService = clockService;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            var entries = eventData.Context?.ChangeTracker.Entries<Auditable>().ToList();
            if (entries != null)
            {
                foreach (EntityEntry<Auditable> entry in entries)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.SetCreatedById(_currentUserService.UserId(Guid.Empty));
                            entry.Entity.SetCreationDate(_clockService.Get());
                            entry.Entity.SetCreatedByName(_currentUserService.UserName(string.Empty));
                            break;
                        case EntityState.Modified:
                            entry.Entity.SetModifiedById(_currentUserService.UserId(Guid.Empty));
                            entry.Entity.SetModificationDate(_clockService.Get());
                            entry.Entity.SetModifiedByName(_currentUserService.UserName(string.Empty));
                            break;
                    }
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
