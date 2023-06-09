using System;
using System.Collections.Generic;

namespace Samples.ModularMonolith.Infrastructure.Persistence.Paging
{
    public class PageResponse<T>
    {
        public PageResponse()
        {
        }

        public PageResponse(List<T> data, int count = 0, int page = 1, int pageSize = 10)
        {
            Items = data;
            CurrentPage = page;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;

        public List<T> Items { get; set; }
    }
}
