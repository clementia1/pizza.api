namespace PizzaApi.Models
{
    public class CheckRateLimitRequest
    {
        public string? RemoteIp { get; set; }
        public string? RequestPath { get; set; }
    }
}