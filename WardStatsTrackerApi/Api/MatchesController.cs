using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiotApiClient;
using WardStatsTrackerApi.Core.Models;

namespace WardStatsTrackerApi.Api
{
    [ResponseCache(Duration = 120)]
    [Route("{platformMoniker}/[controller]")]
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
        public async Task<ActionResult<MatchListModel>> GetMatchHistoryByAccount(string platformMoniker,
            string accountId, [FromQuery] int count = 10)
        {
            var client = _riotApiClientFactory.CreateClient(platformMoniker);
            var matchList = await client.GetMatchList(accountId);

            var matchListModel = _mapper.Map<MatchListModel>(matchList);

            return matchListModel;
        }

        [HttpGet("{matchId}")]
        public async Task<ActionResult<MatchDetailsModel>> GetMatchDetails(string platformMoniker, long matchId)
        {
            var client = _riotApiClientFactory.CreateClient(platformMoniker);
            var match = await client.GetMatch(matchId);

            var matchModel = _mapper.Map<MatchDetailsModel>(match);

            return matchModel;
        }
    }
}