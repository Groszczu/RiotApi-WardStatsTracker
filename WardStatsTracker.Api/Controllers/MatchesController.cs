using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiotApiClient;
using WardStatsTracker.Core.Models;
using WardStatsTracker.Infrastructure.MapperProfiles;

namespace WardStatsTracker.Api.Controllers
{
    [ResponseCache(Duration = 120)]
    [Route("{platformId}/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRiotApiClientFactory _riotApiClientFactory;

        public MatchesController(IRiotApiClientFactory riotApiClientFactory, IMapper mapper)
        {
            _riotApiClientFactory = riotApiClientFactory;
            _mapper = mapper;
        }

        [HttpGet("by-account/{accountId}")]
        public async Task<ActionResult<MatchListModel>> GetMatchHistoryByAccount(string platformId,
            string accountId, [FromQuery] int count = 10)
        {
            var client = _riotApiClientFactory.CreateClient(platformId);
            var matchList = await client.GetMatchList(accountId, endIndex: count);

            var matchListModel = _mapper.Map<MatchListModel>(matchList);

            return matchListModel;
        }

        [HttpGet("{matchId}")]
        public async Task<ActionResult<MatchDetailsModel>> GetMatchDetails(string platformId, long matchId)
        {
            var client = _riotApiClientFactory.CreateClient(platformId);
            var match = await client.GetMatch(matchId);

            var matchModel = _mapper.Map<MatchDetailsModel>(match);

            return matchModel;
        }
    }
}