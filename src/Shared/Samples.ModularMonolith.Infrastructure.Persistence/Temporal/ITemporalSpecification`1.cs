namespace Samples.ModularMonolith.Infrastructure.Persistence.Temporal
{
    public interface ITemporalSpecification<T>
    {
        TemporalCriteria TemporalCriteria { get; set; }
    }
}
