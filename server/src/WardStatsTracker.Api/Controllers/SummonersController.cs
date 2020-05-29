using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WardStatsTracker.Core.Interfaces;
using WardStatsTracker.Core.Models;

namespace WardStatsTracker.Api.Controllers
{
    [ResponseCache(Duration = 300)]
    [Route("{platformId}/summoners")]
    [ApiController]
    public class SummonersController : ControllerBase
    {
        private readonly IRiotService _riotService;

        public SummonersController(IRiotService riotService)
        {
            _riotService = riotService;
        }

        [HttpGet("{summonerName}")]
        public async Task<ActionResult<SummonerModel>> GetSummonerByName(string platformId, string summonerName, 
            [FromQuery] bool includeMatches = true, 
            [FromQuery] bool includeLeagues = true,
            [FromQuery] bool includeMatchDetails = false)
        {
            var summoner = await _riotService.GetSummoner(platformId, summonerName);
            if (summoner == null)
                return NotFound("Summoner with given name could not be find");
            
            if (includeMatches)
            {
                var matchOverviews = await _riotService.GetMatchesByAccount(platformId, summoner.AccountId!) 
                                                          ?? new List<MatchOverviewModel>();
                if (includeMatchDetails)
                {
                    summoner.MatchesWithDetails = await _riotService.GetMatchDetails(platformId, matchOverviews);
                }
                else
                {
                    summoner.Matches = matchOverviews;
                }
            }

            if (includeLeagues)
            {
                summoner.Leagues = await _riotService.GetLeaguesBySummoner(platformId, summoner.Id!);
            }

            return summoner;
        }
    }
}