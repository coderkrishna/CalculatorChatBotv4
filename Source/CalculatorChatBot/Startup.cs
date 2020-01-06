// <copyright file="Startup.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace CalculatorChatBot
{
    using CalculatorChatBot.Bots;
    using CalculatorChatBot.OperationsLib;
    using Microsoft.ApplicationInsights;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Builder.Integration.AspNet.Core;
    using Microsoft.Bot.Connector.Authentication;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Initializes the members of the Startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">All configurations done.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration properties.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Method that gets called by the runtime.
        /// </summary>
        /// <param name="services">All of the services that are required.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Create the credential provider to be used with the Bot Framework Adapter.
            services.AddSingleton<ICredentialProvider, ConfigurationCredentialProvider>();

            // Create the Bot Framework Adapter.
            services.AddSingleton<IBotFrameworkHttpAdapter, BotFrameworkHttpAdapter>();

            services.AddSingleton<IArithmetic>((provider) => new Arithmetic(
                provider.GetRequiredService<TelemetryClient>()));
            services.AddSingleton<IStatistic>((provider) => new Statistic(
                provider.GetRequiredService<TelemetryClient>()));
            services.AddSingleton<IGeometric>((provider) => new Geometric(
                provider.GetRequiredService<TelemetryClient>()));

            services.AddSingleton<ICalcChatBot>((provider) => new CalcChatBot(
                provider.GetRequiredService<TelemetryClient>()));

            // Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
            services.AddTransient<IBot>((provider) => new CalculatorBot(
                provider.GetRequiredService<IConfiguration>(),
                provider.GetRequiredService<IArithmetic>(),
                provider.GetRequiredService<ICalcChatBot>(),
                provider.GetRequiredService<TelemetryClient>(),
                provider.GetRequiredService<IStatistic>(),
                provider.GetRequiredService<IGeometric>()));

            services.AddApplicationInsightsTelemetry();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The current built application.</param>
        /// <param name="env">All of the environment settings.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}