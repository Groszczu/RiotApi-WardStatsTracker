using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RiotApiClient.Models;
using Xunit;

namespace RiotApiClient.IntegrationTests
{
    public class GetMatchListShould : IClassFixture<RiotApiClientFixture>
    {
        public GetMatchListShould(RiotApiClientFixture riotApiClientFixture)
        {
            _riotApiClientFixture = riotApiClientFixture;
        }

        private readonly RiotApiClientFixture _riotApiClientFixture;

        [Fact]
        public async Task ReturnMatchList()
        {
            var client = _riotApiClientFixture.EuropeNordicRiotApiClient;

            var match = await client.GetMatchList("YIDGOiVNVk13syOzWymCbEmWhkJaXA90Qdm_OLithz31yw");

            Assert.IsType<MatchList>(match);
            Assert.IsAssignableFrom<ICollection<MatchOverview>>(match.Matches);
        }

        [Fact]
        public async Task ThrowApiExceptionOnInvalidMatchId()
        {
            var client = _riotApiClientFixture.EuropeNordicRiotApiClient;
            await Assert.ThrowsAsync<ApiException>(() => client.GetMatchList(""));
        }
    }
}