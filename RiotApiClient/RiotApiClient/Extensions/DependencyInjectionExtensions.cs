using Microsoft.Extensions.DependencyInjection;

namespace RiotApiClient.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddRiotApiClientFactory(this IServiceCollection services, string apiKey)
        {
            services.AddSingleton<IRiotApiClientFactory>(sp =>
                new RiotApiClientFactory(apiKey));

            return services;
        }
    }
}