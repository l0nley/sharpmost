using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class ExtraMember
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("nickname")]
        public string Nickname { get; set; } 
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("roles")]
        public string Roles { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}