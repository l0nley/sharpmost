using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class Session
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("create_at")]
        public long CreateAt { get; set; }
        [JsonProperty("expires_at")]
        public long ExpiresAt { get; set; }
        [JsonProperty("last_activity_at")]
        public long LastActivityAt { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("team_id")]
        public string TeamId { get; set; }
        [JsonProperty("device_id")]
        public string DeviceId { get; set; }
        [JsonProperty("roles")]
        public string Roles { get; set; }
        [JsonProperty("is_oauth")]
        public bool IsOAuth { get; set; }
        [JsonProperty("props")]
        public Dictionary<string, string> Props { get; set; }
    }
}