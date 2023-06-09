using System;
using Ardalis.Specification;

namespace Samples.ModularMonolith.Infrastructure.Persistence
{
    public abstract class BaseEntity<TKey> : Auditable, IEntity<TKey>
    {
        protected BaseEntity()
        {
            HandleGuidPrimaryKeyGeneration();
        }

        /// <inheritdoc />
        public TKey Id { get; set; }

        private void HandleGuidPrimaryKeyGeneration()
        {
            if (typeof(TKey) == typeof(Guid))
            {
                GetType().GetProperty(nameof(Id))?.SetValue(this, Guid.NewGuid());
            }
        }
    }
}
