using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class IncomingWebHook
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("create_at")]
        public long CreateAt { get; set; }

        [JsonProperty("update_at")]
        public long UpdateAt { get; set; }

        [JsonProperty("delete_at")]
        public long DeleteAt { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }
    }
}