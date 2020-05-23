using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace WardStatsTracker.Core.Helpers
{
    public static class HeaderDictionaryExtensions
    {
        public static void AddPaginationHeader(this IHeaderDictionary headers, PaginationMetadata metadata)
        {
            headers.Add(PaginationMetadata.HeaderName,
                new StringValues(
                    JsonSerializer.Serialize(metadata, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    })
                )
            );
        }
    }
}