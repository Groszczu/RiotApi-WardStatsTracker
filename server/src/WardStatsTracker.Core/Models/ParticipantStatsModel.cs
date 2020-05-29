namespace WardStatsTracker.Core.Models
{
    public class ParticipantStatsModel
    {
        public bool Win { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int VisionScore { get; set; }
        public int KeystonePerk { get; set; }
        public int PerkPrimaryStyle { get; set; }
        public int PerkSubStyle { get; set; }
    }
}