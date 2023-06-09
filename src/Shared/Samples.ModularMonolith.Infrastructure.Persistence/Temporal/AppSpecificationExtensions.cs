using System;
using Ardalis.Specification;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Temporal
{
    public static class AppSpecificationExtensions
    {
        public static ISpecificationBuilder<T> AsTemporalAll<T>(this ISpecificationBuilder<T> specificationBuilder)
            where T : class
        {
            if (specificationBuilder.Specification is ITemporalSpecification<T> appSpec)
            {
                appSpec.TemporalCriteria = new TemporalAllCriteria();
            }

            return specificationBuilder;
        }

        public static ISpecificationBuilder<T> AsTemporalAsOf<T>(this ISpecificationBuilder<T> specificationBuilder, DateTime asOf)
            where T : class
        {
            if (specificationBuilder.Specification is ITemporalSpecification<T> appSpec)
            {
                appSpec.TemporalCriteria = new TemporalAsOfCriteria(asOf);
            }

            return specificationBuilder;
        }

        public static ISpecificationBuilder<T> AsTemporalFrom<T>(this ISpecificationBuilder<T> specificationBuilder, DateTime from, DateTime to)
            where T : class
        {
            if (specificationBuilder.Specification is ITemporalSpecification<T> appSpec)
            {
                appSpec.TemporalCriteria = new TemporalFromCriteria(from, to);
            }

            return specificationBuilder;
        }

        public static ISpecificationBuilder<T> AsTemporalBetween<T>(this ISpecificationBuilder<T> specificationBuilder, DateTime from, DateTime to)
            where T : class
        {
            if (specificationBuilder.Specification is ITemporalSpecification<T> appSpec)
            {
                appSpec.TemporalCriteria = new TemporalBetweenCriteria(from, to);
            }

            return specificationBuilder;
        }

        public static ISpecificationBuilder<T> AsTemporalContained<T>(this ISpecificationBuilder<T> specificationBuilder, DateTime from, DateTime to)
            where T : class
        {
            if (specificationBuilder.Specification is ITemporalSpecification<T> appSpec)
            {
                appSpec.TemporalCriteria = new TemporalContainedCriteria(from, to);
            }

            return specificationBuilder;
        }
    }
}