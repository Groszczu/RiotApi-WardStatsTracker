using System.Threading.Tasks;
using Refit;
using RiotApiClient.Models;
using Xunit;

namespace RiotApiClient.IntegrationTests
{
    public class GetMatchShould : IClassFixture<RiotApiClientFixture>
    {
        public GetMatchShould(RiotApiClientFixture riotApiClientFixture)
        {
            _riotApiClientFixture = riotApiClientFixture;
        }

        private readonly RiotApiClientFixture _riotApiClientFixture;

        [Fact]
        public async Task ReturnMatch()
        {
            var client = _riotApiClientFixture.EuropeNordicRiotApiClient;

            const uint gameId = 2467628808;
            var match = await client.GetMatch(gameId);

            Assert.IsType<MatchDetails>(match);
            Assert.Equal(gameId, match.GameId);
        }

        [Fact]
        public async Task ThrowApiExceptionOnInvalidMatchId()
        {
            var client = _riotApiClientFixture.EuropeNordicRiotApiClient;
            await Assert.ThrowsAsync<ApiException>(() => client.GetMatch(0));
        }
    }
}