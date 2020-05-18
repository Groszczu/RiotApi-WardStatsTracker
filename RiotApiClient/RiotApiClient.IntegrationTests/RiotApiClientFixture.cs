using Microsoft.Extensions.Configuration;

namespace RiotApiClient.IntegrationTests
{
    public class RiotApiClientFixture
    {
        public RiotApiClientFixture()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<RiotApiClientFixture>();

            var configuration = builder.Build();

            var apiKey = configuration["RiotApi:ApiKey"];

            var clientFactory = new RiotApiClientFactory(apiKey);
            EuropeNordicRiotApiClient = clientFactory.CreateClient(PlatformId.EuropeNordic.Value);
        }

        public IRiotApiClient EuropeNordicRiotApiClient { get; set; }
    }
}