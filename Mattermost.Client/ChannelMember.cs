using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class ChannelMember
    {
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }

        [JsonProperty("notify_props")]
        public Dictionary<string, string> NotifyProps { get; set; }

        [JsonProperty("last_update_at")]
        public long LastUpdateAt { get; set; }
    }
}