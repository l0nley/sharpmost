namespace Mattermost.Client
{
    public class TeamSignup
    {
        public Team Team { get; set; }
        public User User { get; set; }
        public string[] Invites { get; set; }
        public string Data { get; set; }
        public string Hash { get; set; }
    }
}