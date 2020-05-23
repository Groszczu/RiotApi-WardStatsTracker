using System;

namespace WardStatsTracker.Core.Interfaces
{
    public interface IPagedListData
    {
        int TotalCount { get; }
        int PageSize { get; set; }
        int TotalPages => (int) Math.Ceiling((double) TotalCount / PageSize);
        int CurrentPage { get; set; }
        bool HasPrev => CurrentPage > 1;
        bool HasNext => CurrentPage < TotalPages;
    }
}