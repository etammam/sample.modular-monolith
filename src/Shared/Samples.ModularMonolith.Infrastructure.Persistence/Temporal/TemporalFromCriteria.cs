using System;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Temporal
{
    public class TemporalFromCriteria : TemporalCriteria
    {
        public TemporalFromCriteria(DateTime from, DateTime to)
        {
            TemporalFrom = from;
            TemporalTo = to;
        }
    }
}
