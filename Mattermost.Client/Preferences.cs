using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class Preference
    {
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}