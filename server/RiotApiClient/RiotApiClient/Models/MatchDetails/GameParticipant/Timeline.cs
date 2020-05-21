﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RiotApiClient.Models
{
    public class Timeline
    {
        public int ParticipantId { get; set; }
        public Dictionary<string, double>? CreepsPerMinDeltas { get; set; }
        public Dictionary<string, double>? XpPerMinDeltas { get; set; }
        public Dictionary<string, double>? GoldPerMinDeltas { get; set; }
        public Dictionary<string, double>? CsDiffPerMinDeltas { get; set; }
        public Dictionary<string, double>? XpDiffPerMinDeltas { get; set; }
        public Dictionary<string, double>? DamageTakenPerMinDeltas { get; set; }
        public Dictionary<string, double>? DamageTakenDiffPerMinDeltas { get; set; }
        [NotNull] public string? Role { get; set; }
        [NotNull] public string? Lane { get; set; }
    }
}