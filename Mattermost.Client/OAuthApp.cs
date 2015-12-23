using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class OAuthApp
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("creator_id")]
        public string CreatorId { get; set; }

        [JsonProperty("create_at")]
        public long CreateAt { get; set; }

        [JsonProperty("update_at")]
        public long UpdateAt { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("callback_urls")]
        public string[] CallbackUrls { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }
    }
}