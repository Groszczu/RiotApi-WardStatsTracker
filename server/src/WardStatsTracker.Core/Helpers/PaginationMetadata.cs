using WardStatsTracker.Core.Interfaces;

namespace WardStatsTracker.Core.Helpers
{
    public class PaginationMetadata
    {
        public const string HeaderName = "X-Pagination";

        public PaginationMetadata(IPagedListData pagedListData, string? prevPageUrl, string? nextPageUrl)
        {
            TotalCount = pagedListData.TotalCount;
            PageSize = pagedListData.PageSize;
            CurrentPage = pagedListData.CurrentPage;
            TotalPages = pagedListData.TotalPages;

            PrevPageUrl = prevPageUrl;
            NextPageUrl = nextPageUrl;
        }

        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string? PrevPageUrl { get; set; }
        public string? NextPageUrl { get; set; }
    }
}