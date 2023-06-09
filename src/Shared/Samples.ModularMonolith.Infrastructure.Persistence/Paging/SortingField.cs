namespace Samples.ModularMonolith.Infrastructure.Persistence.Paging
{
    public class SortingField
    {
        public SortingField(string field, SortDirection direction)
        {
            Field = field;
            Direction = direction;
        }

        public SortingField()
        {
            Direction = SortDirection.Ascending;
        }

        public string Field { get; set; }

        public SortDirection Direction { get; set; }
    }
}
