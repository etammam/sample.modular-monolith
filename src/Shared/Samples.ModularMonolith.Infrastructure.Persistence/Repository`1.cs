using System;
using System.Linq;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Samples.ModularMonolith.Infrastructure.Persistence.Temporal;

namespace Samples.ModularMonolith.Infrastructure.Persistence
{
    public class Repository<T> : RepositoryBase<T>, IRepository<T>
        where T : class
    {
        private readonly ISpecificationEvaluator _specificationEvaluator;
        private readonly ModuleContext _moduleContext;

        protected Repository(ModuleContext context)
            : base(context, SpecificationEvaluator.Default)
        {
            _moduleContext = context;
            _specificationEvaluator = SpecificationEvaluator.Default;
        }

        public IQueryable<T> AsPage(ISpecification<T> specification)
        {
            return ApplySpecification(specification);
        }

        protected override IQueryable<T> ApplySpecification(ISpecification<T> specification, bool evaluateCriteriaOnly = false)
        {
            var query = EvaluateTemporalCriteria(_moduleContext.Set<T>(), specification);

            return _specificationEvaluator.GetQuery(query, specification, evaluateCriteriaOnly);
        }

        protected override IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification)
        {
            if (specification is null)
                throw new ArgumentNullException(nameof(specification));
            if (specification.Selector is null)
                throw new SelectorNotFoundException();

            var query = EvaluateTemporalCriteria(_moduleContext.Set<T>(), specification);

            return _specificationEvaluator.GetQuery(query, specification);
        }

        private static IQueryable<T> EvaluateTemporalCriteria(DbSet<T> dbSet, ISpecification<T> specification)
        {
            if (specification is not ITemporalSpecification<T> temporalSpecification)
            {
                return dbSet;
            }

            return temporalSpecification.TemporalCriteria switch
            {
                TemporalAllCriteria => dbSet.TemporalAll(),
                TemporalAsOfCriteria temporalAsOfCriteria => dbSet.TemporalAsOf(temporalAsOfCriteria.TemporalFrom!.Value),
                TemporalFromCriteria temporalFromCriteria => dbSet.TemporalFromTo(temporalFromCriteria.TemporalFrom!.Value, temporalFromCriteria.TemporalTo!.Value),
                TemporalBetweenCriteria temporalBetweenCriteria => dbSet.TemporalBetween(temporalBetweenCriteria.TemporalFrom!.Value, temporalBetweenCriteria.TemporalTo!.Value),
                TemporalContainedCriteria temporalContainedCriteria => dbSet.TemporalContainedIn(temporalContainedCriteria.TemporalFrom!.Value, temporalContainedCriteria.TemporalTo!.Value),
                _ => dbSet
            };
        }
    }
}
