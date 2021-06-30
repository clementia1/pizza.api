using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.OpenApi.Extensions;
using PizzaApi.Models;

namespace PizzaApi.Middleware
{
    public class RateLimitMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RateLimitMiddleware> _logger;
        private readonly HttpClient _client;

        public RateLimitMiddleware(
            RequestDelegate next,
            ILogger<RateLimitMiddleware> logger,
            HttpClient client)
        {
            _client = client;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var remoteIp = context.Connection.RemoteIpAddress?.ToString();
            var path = context.Request.Path.Value;

            var request = new CheckRateLimitRequest { RemoteIp = remoteIp, RequestedUrl = path };
            var limit = _client.PostAsJsonAsync("/Check", request);
            await _next.Invoke(context);
        }
    }
}