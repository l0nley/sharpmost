using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class CommandDefinition
    {
        [JsonProperty("command")]
        public string Command { get; set; }
        [JsonProperty("response")]
        public string Response { get; set; }
        [JsonProperty("goto_location")]
        public string GotoLocation { get; set; }
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
        [JsonProperty("-")]
        public bool Suggest { get; set; }
        [JsonProperty("suggestions")]
        public SuggestCommand[] Suggestions { get; set; }
    }
}