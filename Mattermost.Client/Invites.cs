using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class Invites
    {
        [JsonProperty("invites")]
        public string[] Invite { get; set; }
    }
}