using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class ChannelList
    {
        [JsonProperty("channels")]
        public Channel[] Channels { get; set; }
    }
}