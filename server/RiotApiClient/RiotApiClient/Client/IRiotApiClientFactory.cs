namespace RiotApiClient
{
    public interface IRiotApiClientFactory
    {
        public IRiotApiClient CreateClient(string platformId);
    }
}