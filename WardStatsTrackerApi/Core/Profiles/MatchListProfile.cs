using AutoMapper;
using RiotApiClient.Models;
using WardStatsTrackerApi.Core.Models;

namespace WardStatsTrackerApi.Core.Profiles
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