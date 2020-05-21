using System.Diagnostics.CodeAnalysis;

namespace RiotApiClient.Models
{
    public class ParticipantIdentity
    {
        public long ParticipantId { get; set; }
        [NotNull] public Player? Player { get; set; }
    }
}