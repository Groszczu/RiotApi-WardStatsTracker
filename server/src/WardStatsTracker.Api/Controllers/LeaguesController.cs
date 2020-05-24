using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WardStatsTracker.Core.Interfaces;
using WardStatsTracker.Core.Models;

namespace WardStatsTracker.Api.Controllers
{
    [Route("{platformId}/leagues")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly IRiotService _riotService;

        public LeaguesController(IRiotService riotService)
        {
            _riotService = riotService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeagueEntryModel>>> GetLeaguesBySummoner(string platformId,
            [FromQuery] string summonerId)
        {
            var leagues = await _riotService.GetLeaguesBySummoner(platformId, summonerId);
            return leagues.ToList();
        }
    }
}