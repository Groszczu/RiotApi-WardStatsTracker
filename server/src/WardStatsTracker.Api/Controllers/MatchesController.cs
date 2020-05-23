using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet(Name = "GetMatchesByAccount")]
        public async Task<ActionResult<MatchOverviewModel[]>> GetMatchesByAccount(string platformId,
            [FromQuery] string accountId, [FromQuery] MatchesPagingParameters parameters)
        {
            var pagedMatches = await _riotService.GetMatchesByAccount(platformId, accountId, parameters);
            var prevPageUrl =
                pagedMatches.HasPrev ? CreateMatchUrl(accountId, parameters, ResourceUriType.PrevPage) : null;
            var nextPageUrl =
                pagedMatches.HasNext ? CreateMatchUrl(accountId, parameters, ResourceUriType.NextPage) : null;

            Response.Headers.AddPaginationHeader(new PaginationMetadata(pagedMatches, prevPageUrl, nextPageUrl));
            return pagedMatches.ToArray();
        }

        [HttpGet("{matchId}")]
        public async Task<ActionResult<MatchDetailsModel>> GetMatchDetails(string platformId, long matchId)
        {
            return await _riotService.GetMatch(platformId, matchId);
        }

        private string CreateMatchUrl(string accountId, IPagingParameters parameters, ResourceUriType uriType)
        {
            var paramsObject = new
            {
                accountId,
                pageSize = parameters.PageSize,
                page = uriType switch
                {
                    ResourceUriType.PrevPage => parameters.Page - 1,
                    ResourceUriType.NextPage => parameters.Page + 1,
                    _ => parameters.Page
                }
            };

            return Url.Link("GetMatchesByAccount", paramsObject);
        }
    }
}