namespace Samples.ModularMonolith.Infrastructure.Persistence.Paging
{
    public class FilterOptions
    {
        public FilterOptions(string term, string field)
        {
            Term = term;
            Field = field;
        }

        public FilterOptions()
        {
        }

        public string Term { get; set; }

        public string Field { get; set; }

        public FilterOperation Operation { get; set; } = FilterOperation.Contains;
    }
}
