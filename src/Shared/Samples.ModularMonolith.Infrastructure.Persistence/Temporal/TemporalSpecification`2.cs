using Ardalis.Specification;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Temporal
{
    public class TemporalSpecification<T, TResult> : Specification<T, TResult>, ITemporalSpecification<T>
    {
        public TemporalCriteria TemporalCriteria { get; set; }
    }
}