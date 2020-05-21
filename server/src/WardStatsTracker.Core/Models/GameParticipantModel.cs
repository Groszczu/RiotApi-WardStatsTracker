namespace WardStatsTracker.Core.Models
{
    public class GameParticipantModel
    {
        public int ParticipantId { get; set; }
        public int ChampionId { get; set; }
        public int Spell1Id { get; set; }
        public int Spell2Id { get; set; }
        public ParticipantStatsModel? Stats { get; set; }
    }
}