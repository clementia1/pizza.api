using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PizzaApi.Configuration;
using PizzaApi.Data;
using PizzaApi.Data.Cache;
using PizzaApi.DataProviders;
using PizzaApi.DataProviders.Abstractions;
using PizzaApi.Services;
using PizzaApi.Services.Abstractions;

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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                    { Title = "PizzaApi", Version = "v1" });
            });

            services.AddTransient<IRedisCacheConnectionService, RedisCacheConnectionService>();
            services.AddTransient<ICacheService<PizzaCacheEntity>, CacheService<PizzaCacheEntity>>();
            services.AddTransient<IJsonSerializer, JsonSerializer>();

            services.Configure<Config>(AppConfiguration);

            var connectionString = AppConfiguration["PizzaApi:ConnectionString"];
            services.AddDbContext<PizzasDbContext>(
                opts => opts.UseNpgsql(connectionString));

            services.AddTransient<IPizzaProvider, PizzaProvider>();
            services.AddTransient<IPizzaService, PizzaService>();
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

            app.UseRouting();
            app.UseEndpoints(builder => builder.MapDefaultControllerRoute());
        }
    }
}