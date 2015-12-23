using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class Channel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("create_at")]
        public long CreateAt { get; set; }

        [JsonProperty("update_at")]
        public long UpdateAt { get; set; }

        [JsonProperty("delete_at")]
        public long DeleteAt { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        [JsonProperty("last_post_at")]
        public long LastPostAt { get; set; }

        [JsonProperty("total_msg_count")]
        public long TotalMsgCount { get; set; }

        [JsonProperty("extra_update_at")]
        public long ExtraUpdateAt { get; set; }

        [JsonProperty("creator_id")]
        public string CreatorId { get; set; }
    }
}