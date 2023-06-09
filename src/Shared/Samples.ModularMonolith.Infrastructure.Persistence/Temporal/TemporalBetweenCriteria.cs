using System;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Temporal
{
    public class TemporalBetweenCriteria : TemporalCriteria
    {
        public TemporalBetweenCriteria(DateTime from, DateTime to)
        {
            TemporalFrom = from;
            TemporalTo = to;
        }
    }
}
