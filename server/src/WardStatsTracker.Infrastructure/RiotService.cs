using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Refit;
using RiotApiClient;
using RiotApiClient.Models;
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

        public async Task<SummonerModel?> GetSummoner(string platformId, string summonerName)
        {
            var client = _clientFactory.CreateClient(platformId);
            Summoner summoner;
            try
            {
                summoner = await client.GetSummoner(summonerName);
            }
            catch (ApiException)
            {
                return null;
            }

            return _mapper.Map<SummonerModel>(summoner);
        }

        public async Task<PagedList<MatchOverviewModel>?> GetMatchesByAccount(string platformId, string accountId,
            MatchesPagingParameters? parameters)
        {
            var client = _clientFactory.CreateClient(platformId);

            parameters ??= new MatchesPagingParameters();

            var (beginIndex, endIndex) = PagingParametersHelper.ConvertPageParametersToIndices(parameters);

            MatchList matchList;
            try
            {
                matchList = await client.GetMatchList(accountId, beginIndex, endIndex);
            }
            catch (ApiException)
            {
                return null;
            }

            var matches = _mapper.Map<MatchOverviewModel[]>(matchList.Matches);
            var pagedMatchList =
                new PagedList<MatchOverviewModel>(matches, matchList.TotalGames, parameters.Page, parameters.PageSize);

            return pagedMatchList;
        }

        public async Task<MatchDetailsModel> GetMatch(string platformId, long matchId)
        {
            var client = _clientFactory.CreateClient(platformId);
            var matchDetails = await client.GetMatch(matchId);
            return _mapper.Map<MatchDetailsModel>(matchDetails);
        }

        public async Task<List<LeagueEntryModel>> GetLeaguesBySummoner(string platformId, string summonerId)
        {
            var client = _clientFactory.CreateClient(platformId);
            var leagues = await client.GetLeaguesBySummoner(summonerId);
            return _mapper.Map<List<LeagueEntryModel>>(leagues);
        }

        public async Task<List<GameParticipantModel>> GetMatchParticipants(string platformId, long matchId)
        {
            var client = _clientFactory.CreateClient(platformId);
            var matchDetails = await client.GetMatch(matchId);
            var matchDetailsModel = _mapper.Map<MatchDetailsModel>(matchDetails);
            return matchDetailsModel.Participants.ToList();
        }

        public Task<MatchDetailsModel[]> GetMatchDetails(string platformId,
            IEnumerable<MatchOverviewModel> matchOverviews)
        {
            var client = _clientFactory.CreateClient(platformId);
            return Task.WhenAll(matchOverviews.Select(
                async overview =>
                {
                    var matchDetails = await client.GetMatch(overview.GameId);
                    return _mapper.Map<MatchDetailsModel>(matchDetails);
                }));
        }
    }
}