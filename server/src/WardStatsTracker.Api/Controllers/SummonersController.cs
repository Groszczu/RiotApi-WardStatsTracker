using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WardStatsTracker.Core.Interfaces;
using WardStatsTracker.Core.Models;

namespace WardStatsTracker.Api.Controllers
{
    [ResponseCache(Duration = 300)]
    [Route("{platformId}/[controller]")]
    [ApiController]
    public class SummonersController : ControllerBase
    {
        private readonly IRiotService _riotService;

        public SummonersController(IRiotService riotService)
        {
            _riotService = riotService;
        }

        [HttpGet("{summonerName}")]
        public async Task<ActionResult<SummonerModel>> GetSummonerByName(string platformId, string summonerName)
        {
            return await _riotService.GetSummoner(platformId, summonerName);
        }
    }
}