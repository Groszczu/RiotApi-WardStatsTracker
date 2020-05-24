namespace WardStatsTracker.Core.Models
{
    public class ParticipantIdentityModel
    {
        public string? PlatformId { get; set; }
        public string? AccountId { get; set; }
        public string? SummonerName { get; set; }
        public string? SummonerId { get; set; }
        public string? CurrentPlatformId { get; set; }
        public string? CurrentAccountId { get; set; }
        public long ProfileIcon { get; set; }
    }
}