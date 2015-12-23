using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class ChannelExtra
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("member_count")]
        public long MemberCount { get; set; }

        [JsonProperty("members")]
        public ExtraMember[] Members { get; set; }
    }
}