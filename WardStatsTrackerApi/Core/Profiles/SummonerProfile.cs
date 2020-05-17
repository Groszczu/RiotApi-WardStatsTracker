using AutoMapper;
using RiotApiClient.Models;
using WardStatsTrackerApi.Core.Models;

namespace WardStatsTrackerApi.Core.Profiles
{
    public class SummonerProfile : Profile
    {
        public SummonerProfile()
        {
            CreateMap<Summoner, SummonerModel>();
        }
        
    }
}