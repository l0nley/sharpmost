using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class ChannelData
    {
        [JsonProperty("channel")]
        public Channel Channel { get; set; }

        [JsonProperty("member")]
        public ChannelMember Member { get; set; }
    }
}