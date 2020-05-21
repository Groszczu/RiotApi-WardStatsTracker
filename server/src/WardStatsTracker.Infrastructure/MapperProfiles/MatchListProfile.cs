using AutoMapper;
using RiotApiClient.Models;
using WardStatsTracker.Core.Models;

namespace WardStatsTracker.Infrastructure.MapperProfiles
{
    public class MatchListProfile : Profile
    {
        public MatchListProfile()
        {
            CreateMap<MatchList, MatchListModel>();
            CreateMap<MatchOverview, MatchOverviewModel>();
        }
    }
}