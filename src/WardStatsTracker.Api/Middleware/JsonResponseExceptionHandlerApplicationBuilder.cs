using Microsoft.AspNetCore.Builder;

namespace WardStatsTracker.Api.Middleware
{
    public static class JsonResponseExceptionHandlerApplicationBuilder
    {
        public static IApplicationBuilder UseJsonResponseExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<JsonResponseExceptionHandlerMiddleware>();
            return app;
        }
    }
}