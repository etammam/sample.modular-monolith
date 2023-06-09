using System;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Temporal
{
    public abstract class TemporalCriteria
    {
        public DateTime? TemporalFrom { get; protected set; }

        public DateTime? TemporalTo { get; protected set; }
    }
}