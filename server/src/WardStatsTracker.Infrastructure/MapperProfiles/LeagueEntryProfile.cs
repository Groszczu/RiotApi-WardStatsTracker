using AutoMapper;
using RiotApiClient.Models;
using WardStatsTracker.Core.Models;

namespace WardStatsTracker.Infrastructure.MapperProfiles
{
    public class LeagueEntryProfile : Profile
    {
        public LeagueEntryProfile()
        {
            CreateMap<LeagueEntry, LeagueEntryModel>();
        }
    }
}