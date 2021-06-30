namespace PizzaApi.Configuration
{
    public class Config
    {
        public PizzaApiConfig PizzaApi { get; set; } = null!;
        public RedisConfig Redis { get; set; } = null!;
        public IpRateLimitConfig IpRateLimit { get; set; } = null!;
    }
}