namespace Mattermost.Client
{
    public class TeamSettings
    {
        public string SiteName { get; set; }
        public int MaxUsersPerTeam { get; set; }
        public bool EnableTeamCreation { get; set; }
        public bool EnableUserCreation { get; set; }
        public string RestrictCreationToDomains { get; set; }
        public bool RestrictTeamNames { get; set; }
        public bool EnableTeamListing { get; set; }
    }
}