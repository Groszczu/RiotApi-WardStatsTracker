using System;
using System.Net.Http;
using Refit;

namespace RiotApiClient
{
    public class RiotApiClientFactory : IRiotApiClientFactory
    {
        private readonly string _riotApiKey;

        public RiotApiClientFactory(string riotApiKey)
        {
            _riotApiKey = riotApiKey;
        }

        public IRiotApiClient CreateClient(string platformId)
        {
            return RestService.For<IRiotApiClient>(
                new HttpClient(new RiotAuthorizedHttpClientHandler(_riotApiKey))
                {
                    BaseAddress = new Uri($"https://{platformId}.api.riotgames.com")
                });
        }
    }
}