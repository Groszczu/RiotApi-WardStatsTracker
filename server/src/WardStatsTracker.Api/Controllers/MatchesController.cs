using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using WardStatsTracker.Core.Helpers;
using WardStatsTracker.Core.Interfaces;
using WardStatsTracker.Core.Models;
using WardStatsTracker.Core.Parameters;

namespace WardStatsTracker.Api.Controllers
{
    [ResponseCache(Duration = 120)]
    [Route("{platformId}/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IRiotService _riotService;

        public MatchesController(IRiotService riotService)
        {
            _riotService = riotService;
        }

        [HttpGet]
        public async Task<ActionResult<MatchOverviewModel[]>> GetMatchesByAccount(string platformId,
            [FromQuery] string accountId, [FromQuery] MatchesPagingParameters parameters)
        {
            return await _riotService.GetMatchesByAccount(platformId, accountId, parameters);
        }

        [HttpGet("{matchId}")]
        public async Task<ActionResult<MatchDetailsModel>> GetMatchDetails(string platformId, long matchId)
        {
            return await _riotService.GetMatch(platformId, matchId);
        }
    }
}