using System.Threading.Tasks;
using Refit;
using RiotApiClient.Models;
using Xunit;

namespace RiotApiClient.IntegrationTests
{
    public class GetSummonerShould : IClassFixture<RiotApiClientFixture>
    {
        public GetSummonerShould(RiotApiClientFixture riotApiClientFixture)
        {
            _riotApiClientFixture = riotApiClientFixture;
        }

        private readonly RiotApiClientFixture _riotApiClientFixture;

        [Fact]
        public async Task ReturnSummoner()
        {
            var client = _riotApiClientFixture.EuropeNordicRiotApiClient;

            var summoner = await client.GetSummoner("Rochstar");

            Assert.IsType<Summoner>(summoner);
            Assert.Equal("Rochstar", summoner.Name);
        }

        [Fact]
        public async Task ThrowApiExceptionOnInvalidSummonerName()
        {
            var client = _riotApiClientFixture.EuropeNordicRiotApiClient;

            await Assert.ThrowsAsync<ApiException>(() => client.GetSummoner(""));
        }
    }
}