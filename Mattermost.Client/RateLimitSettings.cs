namespace Mattermost.Client
{
    public class RateLimitSettings
    {
        public bool EnableRateLimiter { get; set; }
        public int PerSec { get; set; }
        public int MemoryStoreSize { get; set; }
        public bool VaryByRemoteAddr { get; set; }
        public string VaryByHeader { get; set; }
    }
}