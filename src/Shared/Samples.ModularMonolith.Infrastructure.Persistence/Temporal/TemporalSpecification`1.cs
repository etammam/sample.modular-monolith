using Ardalis.Specification;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Temporal
{
    public class TemporalSpecification<T> : Specification<T>, ITemporalSpecification<T>
    {
        public TemporalCriteria TemporalCriteria { get; set; }
    }
}