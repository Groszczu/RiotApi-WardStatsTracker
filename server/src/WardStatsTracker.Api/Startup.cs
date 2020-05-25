using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RiotApiClient.Extensions;
using WardStatsTracker.Api.Extensions;
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
                .ConfigureControllers();

            services.AddCors(options =>
                options.AddPolicy("AllowClientHost",
                    builder => builder.WithOrigins(Configuration["AllowedHosts"])));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            else app.UseJsonResponseExceptionHandler();

            app.UseCors("AllowClientHost");

            app.UseMvc();
        }
    }
}