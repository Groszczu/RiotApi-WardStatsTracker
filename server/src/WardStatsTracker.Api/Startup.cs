using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RiotApiClient.Extensions;
using WardStatsTracker.Api.Middleware;
using WardStatsTracker.Core.Interfaces;
using WardStatsTracker.Infrastructure;
using WardStatsTracker.Infrastructure.MapperProfiles;

namespace WardStatsTracker.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(SummonerProfile));

            services.AddRiotApiClientFactory(Configuration["RiotApi:ApiKey"]);
            services.AddScoped<IRiotService, RiotService>();

            services.AddControllers(c => c.EnableEndpointRouting = false)
                .ConfigureApiBehaviorOptions(options =>
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
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            else app.UseJsonResponseExceptionHandler();

            app.UseMvc();
        }
    }
}