using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RiotApiClient
{
    public class RiotAuthorizedHttpClientHandler : HttpClientHandler
    {
        private readonly string _riotApiKey;

        public RiotAuthorizedHttpClientHandler(string riotApiKey)
        {
            _riotApiKey = riotApiKey;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.Headers.Add("X-Riot-Token", _riotApiKey);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}