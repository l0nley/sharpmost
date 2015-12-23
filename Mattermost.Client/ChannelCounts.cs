using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class ChannelCounts
    {
        [JsonProperty("counts")]
        public Dictionary<string, long> Counts { get; set; }
        [JsonProperty("update_times")]
        public Dictionary<string, long> UpdateTimes { get; set; }
    }
}