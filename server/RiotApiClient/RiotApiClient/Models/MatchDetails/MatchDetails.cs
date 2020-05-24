using System.Collections.Generic;
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
        public List<Team> Teams { get; private set; }
        public List<GameParticipant> Participants { get; private set; }
        public List<ParticipantIdentity> ParticipantIdentities { get; private set; }

        public MatchDetails()
        {
            Teams = new List<Team>();
            Participants = new List<GameParticipant>();
            ParticipantIdentities = new List<ParticipantIdentity>();
        }
    }
}