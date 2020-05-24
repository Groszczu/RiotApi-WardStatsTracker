using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WardStatsTracker.Core.Interfaces;
using WardStatsTracker.Core.Models;
using WardStatsTracker.Core.Parameters;

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
        public async Task<ActionResult<SummonerModel>> GetSummonerByName(string platformId, string summonerName, [FromQuery] bool includeMatches = false)
        {
            var summoner = await _riotService.GetSummoner(platformId, summonerName);
            if (summoner.AccountId == null)
                return NotFound("Summoner with given name could not be find");
            
            if (!includeMatches)
                return summoner;

            summoner.Matches = await _riotService.GetMatchesByAccount(platformId, summoner.AccountId);

            return summoner;
        }
    }
}