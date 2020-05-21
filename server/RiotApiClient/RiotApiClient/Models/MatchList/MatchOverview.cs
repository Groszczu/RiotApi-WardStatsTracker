using System.Diagnostics.CodeAnalysis;

namespace RiotApiClient.Models
{
    public class MatchOverview
    {
        [NotNull] public string? PlatformId { get; set; }

        public long GameId { get; set; }

        public int Champion { get; set; }

        public int Queue { get; set; }

        public int Season { get; set; }

        public long Timestamp { get; set; }

        [NotNull] public string? Role { get; set; }

        [NotNull] public string? Lane { get; set; }
    }
}