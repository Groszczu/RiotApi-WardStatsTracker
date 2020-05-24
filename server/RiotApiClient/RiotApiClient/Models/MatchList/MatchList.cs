using System.Collections.Generic;

namespace RiotApiClient.Models
{
    public class MatchList
    {
        public List<MatchOverview> Matches { get; set; }

        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int TotalGames { get; set; }

        public MatchList()
        {
            Matches = new List<MatchOverview>();
        }
    }
}