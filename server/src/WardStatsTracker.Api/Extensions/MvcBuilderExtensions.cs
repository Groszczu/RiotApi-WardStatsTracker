using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace WardStatsTracker.Api.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder ConfigureControllers(this IMvcBuilder builder)
        {
            return builder.ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    // create a problem details object
                    var problemDetailsFactory = context.HttpContext.RequestServices
                        .GetRequiredService<ProblemDetailsFactory>();
                    var problemDetails = problemDetailsFactory.CreateValidationProblemDetails(
                        context.HttpContext,
                        context.ModelState);

                    // add additional info not added by default
                    problemDetails.Detail = "See the errors field for details.";
                    problemDetails.Instance = context.HttpContext.Request.Path;

                    // find out which status code to use
                    var actionExecutingContext =
                        context as ActionExecutingContext;

                    // if there are modelstate errors & all arguments were correctly
                    // found/parsed we're dealing with validation errors
                    if (context.ModelState.ErrorCount > 0 &&
                        actionExecutingContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count)
                    {
                        problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
                        problemDetails.Title = "One or more validation errors occurred.";

                        return new UnprocessableEntityObjectResult(problemDetails)
                        {
                            ContentTypes = {"application/problem+json"}
                        };
                    }

                    // if one of the arguments wasn't correctly found / couldn't be parsed
                    // we're dealing with null/unparseable input
                    problemDetails.Status = StatusCodes.Status400BadRequest;
                    problemDetails.Title = "One or more errors on input occurred.";
                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = {"application/problem+json"}
                    };
                };
            }).AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);
        }
    }
}