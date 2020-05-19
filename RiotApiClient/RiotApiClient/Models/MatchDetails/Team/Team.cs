using System.Diagnostics.CodeAnalysis;

namespace RiotApiClient.Models
{
    public class Team
    {
        public long TeamId { get; set; }
        [NotNull] public string? Win { get; set; }
        public bool FirstBlood { get; set; }
        public bool FirstTower { get; set; }
        public bool FirstInhibitor { get; set; }
        public bool FirstBaron { get; set; }
        public bool FirstDragon { get; set; }
        public bool FirstRiftHerald { get; set; }
        public long TowerKills { get; set; }
        public long InhibitorKills { get; set; }
        public long BaronKills { get; set; }
        public long DragonKills { get; set; }
        public long VilemawKills { get; set; }
        public long RiftHeraldKills { get; set; }
        public long DominionVictoryScore { get; set; }
        public Ban[]? Bans { get; set; }
    }
}