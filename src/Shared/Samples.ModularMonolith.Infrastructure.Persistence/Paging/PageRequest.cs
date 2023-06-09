namespace Samples.ModularMonolith.Infrastructure.Persistence.Paging
{
    public class PageRequest
    {
        public PagingOptions PagingOptions { get; set; } = new PagingOptions();

        public FilterOptions FilterBuilder { get; set; }

        public string Filter { get; set; }

        public SortingField SortingField { get; set; }
    }
}
