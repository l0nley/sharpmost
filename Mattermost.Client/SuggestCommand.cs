using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class SuggestCommand
    {
        [JsonProperty("suggestion")]
        public string Suggestion { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}