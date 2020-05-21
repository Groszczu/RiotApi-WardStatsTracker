﻿using System.Diagnostics.CodeAnalysis;

namespace RiotApiClient.Models
{
    public class Summoner
    {
        [NotNull] public string? Id { get; set; }
        [NotNull] public string? AccountId { get; set; }
        [NotNull] public string? Puuid { get; set; }
        [NotNull] public string? Name { get; set; }
        public int ProfileIconId { get; set; }
        public int SummonerLevel { get; set; }
        public long RevisionDate { get; set; }
    }
}