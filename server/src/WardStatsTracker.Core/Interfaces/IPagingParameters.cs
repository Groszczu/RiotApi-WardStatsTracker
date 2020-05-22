namespace WardStatsTracker.Core.Interfaces
{
    public interface IPagingParameters
    {
        int Page { get; set; }
        int PageSize { get; set; }
    }
}