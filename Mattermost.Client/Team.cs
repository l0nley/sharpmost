using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class Team
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("create_at")]
        public long CreateAt { get; set; }
        [JsonProperty("update_at")]
        public long UpdateAt { get; set; }
        [JsonProperty("delete_at")]
        public long DeleteAt { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("company_name")]
        public string CompanyName { get; set; }
        [JsonProperty("allowed_domains")]
        public string AllowedDomains { get; set; }
        [JsonProperty("invite_id")]
        public string InviteId { get; set; }
        [JsonProperty("allow_open_invite")]
        public bool AllowOpenInvite { get; set; }
        [JsonProperty("allow_team_listing")]
        public bool AllowTeamListing { get; set; }
    }
}