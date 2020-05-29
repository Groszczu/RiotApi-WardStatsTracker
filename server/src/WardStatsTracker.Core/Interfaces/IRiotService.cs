using System.Collections.Generic;
using System.Threading.Tasks;
using WardStatsTracker.Core.Helpers;
using WardStatsTracker.Core.Models;
using WardStatsTracker.Core.Parameters;

namespace WardStatsTracker.Core.Interfaces
{
    public interface IRiotService
    {
        Task<SummonerModel?> GetSummoner(string platformId, string summonerName);

        Task<PagedList<MatchOverviewModel>?> GetMatchesByAccount(string platformId, string accountId,
            MatchesPagingParameters? parameters = null);

        Task<MatchDetailsModel> GetMatch(string platformId, long matchId);

        Task<MatchDetailsModel[]>
            GetMatchDetails(string platformId, IEnumerable<MatchOverviewModel> matchOverviews);
        
        Task<List<LeagueEntryModel>> GetLeaguesBySummoner(string platformId, string summonerId);
        Task<List<GameParticipantModel>> GetMatchParticipants(string platformId, long matchId);
    }
}