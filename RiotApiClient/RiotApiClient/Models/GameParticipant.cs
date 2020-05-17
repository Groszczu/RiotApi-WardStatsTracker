using System.Diagnostics.CodeAnalysis;

namespace RiotApiClient.Models
{
    public class GameParticipant
    {
        public int ParticipantId { get; set; }
        public int ChampionId { get; set; }
        public int Spell1Id { get; set; }
        public int Spell2Id { get; set; }
        [NotNull] public GameStats? Stats { get; set; }
    }
}