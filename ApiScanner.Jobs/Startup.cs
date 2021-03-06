﻿using System;
using ApiScanner.Business.Jobs;
using ApiScanner.DataAccess;
using ApiScanner.DataAccess.Repositories;
using ApiScanner.Entities.Configs;
using ApiScanner.Entities.Enums;
using ApiScanner.Jobs.Managers;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiScanner.Jobs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure DataBase contexts
            CoreContext.ConnectionString = Configuration.GetConnectionString("DataAccessPostgreSqlProvider");
            services.AddDbContext<CoreContext>();
            services.Configure<JobConfigOptions>(Configuration.GetSection("JobConfig"));

            services.AddScoped<IJobApiCompile, JobApiCompile>();
            services.AddTransient<IApiRepository, ApiRepository>();
            services.AddTransient<IApiLogRepository, ApiLogRepository>();

            services.AddHangfire(c => c.UseMemoryStorage());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            app.UseHangfireDashboard("/hangfire");
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate<ApiRunJob>("HourlyApis", x => x.ExecuteJobAsync(ApiInterval.Hourly), Cron.Hourly);
            RecurringJob.AddOrUpdate<ApiRunJob>("DailyApis", x => x.ExecuteJobAsync(ApiInterval.Daily), Cron.Daily);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("ApiScanner jobs. Navigate to /hangfire for dashboard.");
            });
        }
    }
}
