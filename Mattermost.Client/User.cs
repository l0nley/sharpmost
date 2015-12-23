using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("create_at")]
        public long CreateAt { get; set; }
        [JsonProperty("update_at")]
        public long UpdateAt { get; set; }
        [JsonProperty("delete_at")]
        public long DeleteAt { get; set; }
        [JsonProperty("team_id")]
        public string TeamId { get; set; }
        [JsonProperty("username")]
        public string UserName { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("auth_data")]
        public string AuthData { get; set; }
        [JsonProperty("auth_service")]
        public string AuthService { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }
        [JsonProperty("nickname")]
        public string NickName { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("roles")]
        public string Roles { get; set; }
        [JsonProperty("last_activity_at")]
        public long LastActivityAt { get; set; }
        [JsonProperty("last_ping_at")]
        public long LastPingAt { get; set; }
        [JsonProperty("allow_marketing")]
        public bool AllowMarketing { get; set; }
        [JsonProperty("props")]
        public Dictionary<string,string> Props { get; set; }
        [JsonProperty("notify_props")]
        public Dictionary<string,string> NotifyProps { get; set; }
        [JsonProperty("theme_props")]
        public Dictionary<string, string> ThemeProps { get; set; }
        [JsonProperty("last_password_update")]
        public long LastPasswordUpdate { get; set; }
        [JsonProperty("last_picture_update")]
        public long LastPictureUpdate { get; set; }
        [JsonProperty("failed_attempts")]
        public int FailedAttempts { get; set; }
    }
}