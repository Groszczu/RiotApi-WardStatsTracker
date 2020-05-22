using AutoMapper;
using RiotApiClient.Models;
using WardStatsTracker.Core.Models;

namespace WardStatsTracker.Infrastructure.MapperProfiles
{
    public class MatchOverviewProfile : Profile
    {
        public MatchOverviewProfile()
        {
            CreateMap<MatchOverview, MatchOverviewModel>();
        }
    }
}