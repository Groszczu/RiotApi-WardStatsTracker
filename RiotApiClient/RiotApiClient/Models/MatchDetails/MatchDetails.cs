using System.Diagnostics.CodeAnalysis;

namespace RiotApiClient.Models
{
    public class MatchDetails
    {
        public long GameId { get; set; }
        public long GameDuration { get; set; }
        public long GameCreation { get; set; }
        [NotNull] public string? PlatformId { get; set; }
        public int QueueId { get; set; }
        public int MapId { get; set; }
        public int SeasonId { get; set; }
        [NotNull] public string? GameVersion { get; set; }
        [NotNull] public string? GameMode { get; set; }
        [NotNull] public string? GameType { get; set; }
        [NotNull] public Team[]? Teams { get; set; }
        [NotNull] public GameParticipant[]? Participants { get; set; }
        [NotNull] public ParticipantIdentity[]? ParticipantIdentities { get; set; }
    }
}