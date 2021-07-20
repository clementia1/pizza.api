using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PizzaApi.Configuration;
using PizzaApi.Models;

namespace PizzaApi.Filters
{
    public class RateLimit : IAsyncActionFilter
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<RateLimit> _logger;
        private readonly Config _config;

        public RateLimit(
            IHttpClientFactory clientFactory,
            IOptions<Config> config,
            ILogger<RateLimit> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
            _config = config.Value;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var checkRateLimitRequest = new CheckRateLimitRequest
            {
                RemoteIp = context.HttpContext.Connection.RemoteIpAddress!.ToString(),
                RequestedUrl = context.HttpContext.Request.Path.Value!
            };

            _logger.LogInformation($"RemoteIp: {checkRateLimitRequest.RemoteIp}");
            _logger.LogInformation($"RequestedUrl: {checkRateLimitRequest.RequestedUrl}");

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Origin", "PizzaApi");
            var response = await client.PostAsJsonAsync(_config.IpRateLimit.Url, checkRateLimitRequest);

            if (response.StatusCode is HttpStatusCode.TooManyRequests)
            {
                context.Result = new StatusCodeResult(429);
            }
            else
            {
                await next();
            }
        }
    }
}