using AutoMapper;
using RiotApiClient.Models;
using WardStatsTracker.Core.Models;

namespace WardStatsTracker.Infrastructure.MapperProfiles
{
    public class SummonerProfile : Profile
    {
        public SummonerProfile()
        {
            CreateMap<Summoner, SummonerModel>();
        }
    }
}