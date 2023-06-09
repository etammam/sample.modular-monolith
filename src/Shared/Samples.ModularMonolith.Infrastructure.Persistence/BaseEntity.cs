using System;
using Ardalis.Specification;

namespace Samples.ModularMonolith.Infrastructure.Persistence
{
    /// <inheritdoc cref="BaseEntity{TKey}" />
    public abstract class BaseEntity : BaseEntity<Guid>, IEntity<Guid>
    {
    }
}
