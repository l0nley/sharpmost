using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class Audit
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("create_at")]
        public long CreateAt { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("extra_info")]
        public string ExtraInfo { get; set; }
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
    }
}