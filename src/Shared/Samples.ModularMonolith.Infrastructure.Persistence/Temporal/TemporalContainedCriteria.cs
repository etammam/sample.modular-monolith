using System;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Temporal
{
    public class TemporalContainedCriteria : TemporalCriteria
    {
        public TemporalContainedCriteria(DateTime from, DateTime to)
        {
            TemporalFrom = from;
            TemporalTo = to;
        }
    }
}
