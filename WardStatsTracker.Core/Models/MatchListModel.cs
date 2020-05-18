namespace WardStatsTracker.Core.Models
{
    public class MatchListModel
    {
        public MatchOverviewModel[]? Matches { get; set; }

        public int TotalGames { get; set; }
    }
}