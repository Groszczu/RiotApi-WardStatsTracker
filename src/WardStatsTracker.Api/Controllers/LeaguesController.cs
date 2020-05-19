using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiotApiClient;
using WardStatsTracker.Core.Models;

namespace WardStatsTracker.Api.Controllers
{
    [Route("{platformId}/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRiotApiClientFactory _riotApiClientFactory;

        public LeaguesController(IRiotApiClientFactory riotApiClientFactory, IMapper mapper)
        {
            _riotApiClientFactory = riotApiClientFactory;
            _mapper = mapper;
        }

        [HttpGet("by-summoner/{summonerId}")]
        public async Task<ActionResult<LeagueEntryModel[]>> GetLeaguesBySummoner(string platformId, string summonerId)
        {
            var client = _riotApiClientFactory.CreateClient(platformId);
            var leagues = await client.GetLeaguesBySummoner(summonerId);

            var leagueModels = _mapper.Map<LeagueEntryModel[]>(leagues);

            return leagueModels;
        }
    }
}