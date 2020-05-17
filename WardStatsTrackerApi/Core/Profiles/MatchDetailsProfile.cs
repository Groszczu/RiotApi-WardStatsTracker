using AutoMapper;
using RiotApiClient.Models;
using WardStatsTrackerApi.Core.Models;

namespace WardStatsTrackerApi.Core.Profiles
{
    public class MatchDetailsProfile : Profile
    {
        public MatchDetailsProfile()
        {
            CreateMap<MatchDetails, MatchDetailsModel>();
            CreateMap<GameParticipant, GameParticipantModel>();
            CreateMap<GameStats, GameStatsModel>();
        }
    }
}