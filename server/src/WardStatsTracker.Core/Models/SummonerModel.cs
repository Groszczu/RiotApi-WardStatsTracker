
using System.Collections.Generic;

namespace WardStatsTracker.Core.Models
{
    public class SummonerModel
    {
        public string? Id { get; set; }
        public string? AccountId { get; set; }
        public string? Name { get; set; }
        public int SummonerLevel { get; set; }
        public IList<MatchOverviewModel>? Matches { get; set; } = null;
    }
}