using System.Diagnostics.CodeAnalysis;

namespace WardStatsTracker.Core.Models
{
    public class SummonerModel
    {
        [NotNull] public string? Id { get; set; }

        [NotNull] public string? AccountId { get; set; }

        [NotNull] public string? Name { get; set; }

        public int SummonerLevel { get; set; }
    }
}