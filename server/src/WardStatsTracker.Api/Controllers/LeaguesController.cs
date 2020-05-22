using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WardStatsTracker.Core.Interfaces;
using WardStatsTracker.Core.Models;

namespace WardStatsTracker.Api.Controllers
{
    [Route("{platformId}/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly IRiotService _riotService;

        public LeaguesController(IRiotService riotService)
        {
            _riotService = riotService;
        }

        [HttpGet]
        public async Task<ActionResult<LeagueEntryModel[]>> GetLeaguesBySummoner(string platformId,
            [FromQuery] string summonerId)
        {
            return await _riotService.GetLeaguesBySummoner(platformId, summonerId);
        }
    }
}