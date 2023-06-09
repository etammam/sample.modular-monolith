using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Samples.ModularMonolith.Infrastructure.Persistence
{
    public interface IGenericContext
    {
        DatabaseFacade Database { get; }

        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        DbSet<TEntity> Set<TEntity>(string name)
            where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        EntityEntry Entry(object entity);

        EntityEntry<TEntity> Add<TEntity>(TEntity entity)
            where TEntity : class;

        EntityEntry<TEntity> Update<TEntity>(TEntity entity)
            where TEntity : class;

        EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
            where TEntity : class;

        EntityEntry Add(object entity);

        ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default);

        EntityEntry<TEntity> Attach<TEntity>(TEntity entity)
            where TEntity : class;

        EntityEntry Attach(object entity);

        EntityEntry Update(object entity);

        EntityEntry Remove(object entity);

        void AddRange(params object[] entities);

        Task AddRangeAsync(params object[] entities);

        Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default);

        void RemoveRange(IEnumerable<object> entities);

        object Find(Type entityType, params object[] keyValues);

        ValueTask<object> FindAsync(Type entityType, params object[] keyValues);

        ValueTask<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken);

        TEntity Find<TEntity>(params object[] keyValues)
            where TEntity : class;

        ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues)
            where TEntity : class;

        ValueTask<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken)
            where TEntity : class;

        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
