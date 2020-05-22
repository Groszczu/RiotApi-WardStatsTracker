using System.Threading.Tasks;
using AutoMapper;
using RiotApiClient;
using WardStatsTracker.Core.Helpers;
using WardStatsTracker.Core.Interfaces;
using WardStatsTracker.Core.Models;
using WardStatsTracker.Core.Parameters;

namespace WardStatsTracker.Infrastructure
{
    public class RiotService : IRiotService
    {
        private readonly IRiotApiClientFactory _clientFactory;
        private readonly IMapper _mapper;

        public RiotService(IRiotApiClientFactory clientFactory, IMapper mapper)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
        }

        public async Task<SummonerModel> GetSummoner(string platformId, string summonerName)
        {
            var client = _clientFactory.CreateClient(platformId);
            var summoner = await client.GetSummoner(summonerName);
            return _mapper.Map<SummonerModel>(summoner);
        }

        public async Task<MatchOverviewModel[]> GetMatchesByAccount(string platformId, string accountId,
            MatchesPagingParameters parameters)
        {
            var client = _clientFactory.CreateClient(platformId);

            var (startIndex, endIndex) = PagingParametersHelper.ConvertPageParametersToIndices(parameters);

            var matchList = await client.GetMatchList(accountId, startIndex, endIndex);
            return _mapper.Map<MatchOverviewModel[]>(matchList.Matches);
        }

        public async Task<MatchDetailsModel> GetMatch(string platformId, long matchId)
        {
            var client = _clientFactory.CreateClient(platformId);
            var matchDetails = await client.GetMatch(matchId);
            return _mapper.Map<MatchDetailsModel>(matchDetails);
        }

        public async Task<LeagueEntryModel[]> GetLeaguesBySummoner(string platformId, string summonerId)
        {
            var client = _clientFactory.CreateClient(platformId);
            var leagues = await client.GetLeaguesBySummoner(summonerId);
            return _mapper.Map<LeagueEntryModel[]>(leagues);
        }
    }
}