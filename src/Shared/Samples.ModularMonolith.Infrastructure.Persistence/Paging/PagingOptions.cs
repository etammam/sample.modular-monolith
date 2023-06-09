namespace Samples.ModularMonolith.Infrastructure.Persistence.Paging
{
    public class PagingOptions
    {
        public PagingOptions()
        {
        }

        public PagingOptions(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }

        public int PageSize { get; set; } = 10;

        public int PageNumber { get; set; } = 1;
    }
}
