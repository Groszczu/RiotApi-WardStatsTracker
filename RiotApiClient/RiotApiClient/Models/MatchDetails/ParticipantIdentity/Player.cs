using System.Diagnostics.CodeAnalysis;

namespace RiotApiClient.Models
{
    public class Player
    {
        [NotNull] public string? PlatformId { get; set; }
        [NotNull] public string? AccountId { get; set; }
        [NotNull] public string? SummonerName { get; set; }
        [NotNull] public string? SummonerId { get; set; }
        [NotNull] public string? CurrentPlatformId { get; set; }
        [NotNull] public string? CurrentAccountId { get; set; }
        [NotNull] public string? MatchHistoryUri { get; set; }
        public long ProfileIcon { get; set; }
    }
}