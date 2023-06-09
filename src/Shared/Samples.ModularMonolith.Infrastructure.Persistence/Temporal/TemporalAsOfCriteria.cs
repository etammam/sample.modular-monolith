using System;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Temporal
{
    public class TemporalAsOfCriteria : TemporalCriteria
    {
        public TemporalAsOfCriteria(DateTime asOf)
        {
            TemporalFrom = asOf;
        }
    }
}
