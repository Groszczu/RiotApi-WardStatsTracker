using System.Text.Json;
using Refit;

namespace WardStatsTracker.Core.Helpers
{
    public static class ApiExceptionExtensions
    {
        public static string ToJson(this ApiException exception)
        {
            return JsonSerializer.Serialize(new
            {
                error = new
                {
                    message = exception.Message,
                    statusCode = (int) exception.StatusCode
                }
            });
        }
    }
}