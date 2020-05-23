using System;
using System.Collections.Generic;
using WardStatsTracker.Core.Interfaces;

namespace WardStatsTracker.Core.Helpers
{
    public class PagedList<T> : List<T>, IPagedListData
    {
        public PagedList(IEnumerable<T> elements, int totalCount, int page, int pageSize)
        {
            TotalCount = totalCount;
            PageSize = pageSize;

            if (page > TotalPages) throw new ArgumentOutOfRangeException(nameof(page));

            CurrentPage = page;
            AddRange(elements);
        }

        public int TotalCount { get; }
        public int PageSize { get; set; }
        public int TotalPages => (int) Math.Ceiling((double) TotalCount / PageSize);
        public int CurrentPage { get; set; }
        public bool HasPrev => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}