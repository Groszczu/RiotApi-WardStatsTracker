using AutoMapper;
using RiotApiClient.Models;
using WardStatsTracker.Core.Models;

namespace WardStatsTracker.Infrastructure.MapperProfiles
{
    public class MatchDetailsProfile : Profile
    {
        public MatchDetailsProfile()
        {
            CreateMap<MatchDetails, MatchDetailsModel>();
            CreateMap<GameParticipant, GameParticipantModel>();
            CreateMap<ParticipantStats, ParticipantStatsModel>();
        }
    }
}