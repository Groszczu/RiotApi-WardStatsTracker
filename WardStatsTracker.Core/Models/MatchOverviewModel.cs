namespace WardStatsTracker.Core.Models
{
    public class MatchOverviewModel
    {
        public string? PlatformId { get; set; }

        public long GameId { get; set; }

        public int Champion { get; set; }

        public int Queue { get; set; }

        public int Season { get; set; }

        public long Timestamp { get; set; }

        public string? Role { get; set; }

        public string? Lane { get; set; }
    }
}