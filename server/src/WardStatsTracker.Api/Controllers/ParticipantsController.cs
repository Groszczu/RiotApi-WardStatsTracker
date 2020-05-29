using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WardStatsTracker.Core.Interfaces;
using WardStatsTracker.Core.Models;

namespace WardStatsTracker.Api.Controllers
{
    [Route("{platformId}/matches/{matchId}/participants")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IRiotService _riotService;

        public ParticipantsController(IRiotService riotService)
        {
            _riotService = riotService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameParticipantModel>>> GetParticipants(string platformId,
            long matchId)
        {
            return await _riotService.GetMatchParticipants(platformId, matchId);
        }
    }
}