using System;
using StackExchange.Redis;

namespace PizzaApi.Services.Abstractions
{
    public interface IRedisCacheConnectionService
    {
        public IConnectionMultiplexer Connection { get; }
    }
}