using System.Collections.Generic;

namespace WardStatsTracker.Core.Models
{
    public class MatchDetailsModel
    {
        public long GameId { get; set; }
        public long GameDuration { get; set; }
        public long GameCreation { get; set; }
        public string? PlatformId { get; set; }
        public int QueueId { get; set; }
        public int MapId { get; set; }
        public IList<GameParticipantModel> Participants { get; private set; }

        public MatchDetailsModel()
        {
            Participants = new List<GameParticipantModel>();
        }
    }
}