using System;
using System.Threading.Tasks;
using StackExchange.Redis;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PizzaApi.Configuration;
using PizzaApi.Data.Cache;
using PizzaApi.Services.Abstractions;

namespace PizzaApi.Services
{
    public class CacheService<TCacheEntity> : ICacheService<TCacheEntity>
        where TCacheEntity : class, ICacheEntity
    {
        private readonly ILogger<CacheService<TCacheEntity>> _logger;
        private readonly IRedisCacheConnectionService _redisCacheConnectionService;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly Config _config;

        public CacheService(
            ILogger<CacheService<TCacheEntity>> logger,
            IRedisCacheConnectionService redisCacheConnectionService,
            IOptions<Config> config,
            IJsonSerializer jsonSerializer)
        {
            _logger = logger;
            _redisCacheConnectionService = redisCacheConnectionService;
            _jsonSerializer = jsonSerializer;
            _config = config.Value;
        }

        public Task AddOrUpdateAsync(TCacheEntity entity, string userName) => AddOrUpdateInternalAsync(entity, userName);

        public async Task<TCacheEntity?> GetAsync(int id, string userName)
        {
            var redis = GetRedisDatabase();

            var cacheKey = GetItemCacheKey(id, userName);

            var serialized = await redis.StringGetAsync(cacheKey);

            return !string.IsNullOrEmpty(serialized) ? _jsonSerializer.Deserialize<TCacheEntity>(serialized) : null;
        }

        public async Task RemoveAsync(int id, string userName)
        {
            var redis = GetRedisDatabase();

            var cacheKey = GetItemCacheKey(id, userName);

            if (await redis.KeyDeleteAsync(cacheKey))
            {
                _logger.LogInformation($"{typeof(TCacheEntity).Name} with id {id.ToString()} of user '{userName}' was removed from cache.");
            }
            else
            {
                _logger.LogWarning($"Can't remove {typeof(TCacheEntity).Namespace} with id {id} of user '{userName}'.");
            }
        }

        private string GetItemCacheKey(int id, string userName) => $"{userName}_{id:N}";

        private async Task AddOrUpdateInternalAsync(TCacheEntity entity, string userName, IDatabase? redis = null, TimeSpan? expiry = null)
        {
            redis = redis ?? GetRedisDatabase();
            expiry = expiry ?? _config.Redis.CacheTimeout;

            var cacheKey = GetItemCacheKey(entity.Id, userName);
            var serialized = _jsonSerializer.Serialize(entity);

            if (await redis.StringSetAsync(cacheKey, serialized, expiry))
            {
                _logger.LogInformation($"{typeof(TCacheEntity).Name} for user {userName} cached. New data: {serialized}");
            }
            else
            {
                _logger.LogInformation($"{typeof(TCacheEntity).Name} for user {userName} updated. New data: {serialized}");
            }
        }

        private IDatabase GetRedisDatabase() => _redisCacheConnectionService.Connection.GetDatabase();
    }
}