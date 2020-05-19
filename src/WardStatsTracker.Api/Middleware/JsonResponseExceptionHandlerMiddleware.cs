using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Refit;
using WardStatsTracker.Core.Error;

namespace WardStatsTracker.Api.Middleware
{
    public class JsonResponseExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public JsonResponseExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                await HandleStatusCodeException(context, ex);
            }
        }

        private static async Task HandleStatusCodeException(HttpContext context, ApiException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) ex.StatusCode;

            await context.Response.WriteAsync(ex.ToJson());
        }
    }
}