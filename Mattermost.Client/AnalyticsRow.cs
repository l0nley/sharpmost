using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class AnalyticsRow
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public double Value { get; set; }
    }
}