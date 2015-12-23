using Newtonsoft.Json;
// ReSharper disable InconsistentNaming

namespace Mattermost.Client
{
    public class OutgoingWebHook
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("create_at")]
        public long CreateAt { get; set; }

        [JsonProperty("update_at")]
        public long UpdateAt { get; set; }

        [JsonProperty("delete_at")]
        public long DeleteAt { get; set; }

        [JsonProperty("creator_id")]
        public string CreatorId { get; set; }

        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("team_id")]
        public string TeamId { get; set; }

        [JsonProperty("trigger_words")]
        public string[] TriggerWords { get; set; }

        [JsonProperty("callback_urls")]
        public string[] CallbackURLs { get; set; }
    }
}