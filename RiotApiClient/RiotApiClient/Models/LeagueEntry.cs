using System.Diagnostics.CodeAnalysis;

namespace RiotApiClient.Models
{
    public class LeagueEntry
    {
        [NotNull] public string? LeagueId { get; set; }
        [NotNull] public string? SummonerId { get; set; }
        [NotNull] public string? SummonerName { get; set; }
        [NotNull] public string? QueueType { get; set; }
        [NotNull] public string? Tier { get; set; }
        [NotNull] public string? Rank { get; set; }
        public int LeaguePoints { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public bool HotStreak { get; set; }
        public bool Veteran { get; set; }
        public bool FreshBlood { get; set; }
        public bool Inactive { get; set; }
    }
}