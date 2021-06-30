using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using PizzaApi.Configuration;
using PizzaApi.Models;

namespace PizzaApi.Filters
{
    public class RateLimitAsyncResourceFilter : IAsyncActionFilter
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly Config _config;

        public RateLimitAsyncResourceFilter(
            IHttpClientFactory clientFactory,
            IOptions<Config> config)
        {
            _clientFactory = clientFactory;
            _config = config.Value;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var checkRateLimitRequest = new CheckRateLimitRequest
            {
                RemoteIp = context.HttpContext.Connection.RemoteIpAddress?.ToString(),
                RequestedUrl = context.HttpContext.Request.Path.Value
            };

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Origin", "PizzaApi");
            var response = await client.PostAsJsonAsync(_config.IpRateLimit.Url, checkRateLimitRequest);

            if (response.StatusCode is HttpStatusCode.TooManyRequests)
            {
                context.Result = new StatusCodeResult(429);
            }

            await next();
        }
    }
}