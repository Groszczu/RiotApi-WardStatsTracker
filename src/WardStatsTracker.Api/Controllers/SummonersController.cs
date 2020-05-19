using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiotApiClient;
using WardStatsTracker.Core.Models;

namespace WardStatsTracker.Api.Controllers
{
    [ResponseCache(Duration = 300)]
    [Route("{platformId}/[controller]")]
    [ApiController]
    public class SummonersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRiotApiClientFactory _riotApiClientFactory;

        public SummonersController(IRiotApiClientFactory riotApiClientFactory, IMapper mapper)
        {
            _riotApiClientFactory = riotApiClientFactory;
            _mapper = mapper;
        }

        [HttpGet("{summonerName}")]
        public async Task<ActionResult<SummonerModel>> GetSummonerByName(string platformId, string summonerName)
        {
            var client = _riotApiClientFactory.CreateClient(platformId);
            var summoner = await client.GetSummoner(summonerName);

            var summonerModel = _mapper.Map<SummonerModel>(summoner);
            return summonerModel;
        }
    }
}