using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PizzaApi.Automapper;
using PizzaApi.Configuration;
using PizzaApi.Data;
using PizzaApi.Data.Cache;
using PizzaApi.DataProviders;
using PizzaApi.DataProviders.Abstractions;
using PizzaApi.Filters;
using PizzaApi.Services;
using PizzaApi.Services.Abstractions;
using Serilog;
using Slugify;

namespace PizzaApi
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            AppConfiguration = builder.Build();
        }

        public IConfiguration AppConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddHttpClient();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                    { Title = "PizzaApi", Version = "v1" });
            });

            services.AddScoped<RateLimit>();
            services.AddTransient<ISlugHelper, SlugHelper>();
            services.AddTransient<IRedisCacheConnectionService, RedisCacheConnectionService>();
            services.AddTransient<ICacheService<PizzaCacheEntity>, CacheService<PizzaCacheEntity>>();
            services.AddTransient<IJsonSerializer, JsonSerializer>();
            services.AddTransient<IPizzaProvider, PizzaProvider>();
            services.AddTransient<IPizzaService, PizzaService>();
            services.AddScoped<IDbContextWrapper<PizzasDbContext>, DbContextWrapper<PizzasDbContext>>();

            services.Configure<Config>(AppConfiguration);

            var connectionString = AppConfiguration["PizzaApi:ConnectionString"];
            services.AddDbContextFactory<PizzasDbContext>(
                opts =>
                {
                    opts.UseNpgsql(connectionString);
                    opts.UseSnakeCaseNamingConvention();
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint(
                        "/swagger/v1/swagger.json",
                        "PizzaApi v1"));
            }

            app.UseSerilogRequestLogging();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin());

            app.UseEndpoints(builder => builder.MapDefaultControllerRoute());
        }
    }
}