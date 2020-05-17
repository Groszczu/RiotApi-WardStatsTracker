using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiotApiClient;
using WardStatsTrackerApi.Core.Models;

namespace WardStatsTrackerApi.Api
{
    [ResponseCache(Duration = 300)]
    [Route("{platformMoniker}/[controller]")]
    [ApiController]
    public class SummonersController : ControllerBase
    {
        private readonly IRiotApiClientFactory _riotApiClientFactory;
        private readonly IMapper _mapper;

        public SummonersController(IRiotApiClientFactory riotApiClientFactory, IMapper mapper)
        {
            _riotApiClientFactory = riotApiClientFactory;
            _mapper = mapper;
        }

        [HttpGet("{summonerName}")]
        public async Task<ActionResult<SummonerModel>> GetSummonerByName(string platformMoniker, string summonerName)
        {
            var client = _riotApiClientFactory.CreateClient(platformMoniker);
            var summoner = await client.GetSummoner(summonerName);

            var summonerModel = _mapper.Map<SummonerModel>(summoner);
            return summonerModel;
        }
    }
}