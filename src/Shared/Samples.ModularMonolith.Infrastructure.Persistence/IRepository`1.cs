using System.Linq;
using Ardalis.Specification;

namespace Samples.ModularMonolith.Infrastructure.Persistence
{
    public interface IRepository<T> : IRepositoryBase<T>
        where T : class
    {
        IQueryable<T> AsPage(ISpecification<T> specification);
    }
}
