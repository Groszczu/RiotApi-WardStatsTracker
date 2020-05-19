using System.Threading.Tasks;
using Refit;
using RiotApiClient.Models;
using Xunit;

namespace RiotApiClient.IntegrationTests
{
    public class GetLeaguesBySummonerShould : IClassFixture<RiotApiClientFixture>
    {
        public GetLeaguesBySummonerShould(RiotApiClientFixture riotApiClientFixture)
        {
            _riotApiClientFixture = riotApiClientFixture;
        }

        private readonly RiotApiClientFixture _riotApiClientFixture;

        [Fact]
        public async Task ReturnLeaguesArray()
        {
            var client = _riotApiClientFixture.EuropeNordicRiotApiClient;

            var leagues = await client.GetLeaguesBySummoner("12H6BKorGqmL9_B2n0w6ee2YTWcbBZMZWek0-EKueJ_mqWg");

            Assert.IsType<LeagueEntry[]>(leagues);
        }

        [Fact]
        public async Task ThrowApiExceptionOnInvalidMatchId()
        {
            var client = _riotApiClientFixture.EuropeNordicRiotApiClient;
            await Assert.ThrowsAsync<ApiException>(() => client.GetLeaguesBySummoner(""));
        }
    }
}