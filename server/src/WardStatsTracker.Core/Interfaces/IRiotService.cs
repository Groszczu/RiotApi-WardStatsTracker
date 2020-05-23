using System.Threading.Tasks;
using WardStatsTracker.Core.Helpers;
using WardStatsTracker.Core.Models;
using WardStatsTracker.Core.Parameters;

namespace WardStatsTracker.Core.Interfaces
{
    public interface IRiotService
    {
        Task<SummonerModel> GetSummoner(string platformId, string summonerName);

        Task<PagedList<MatchOverviewModel>> GetMatchesByAccount(string platformId, string accountId,
            MatchesPagingParameters parameters);

        Task<MatchDetailsModel> GetMatch(string platformId, long matchId);
        Task<LeagueEntryModel[]> GetLeaguesBySummoner(string platformId, string summonerId);
    }
}