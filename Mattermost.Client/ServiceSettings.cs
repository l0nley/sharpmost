namespace Mattermost.Client
{
    public class ServiceSettings
    {
        public string ListenAddress { get; set; }
        public int MaximumLoginAttempts { get; set; }
        public string SegmentDeveloperKey { get; set; }
        public string GoogleDeveloperKey { get; set; }
        public bool EnableOAuthServiceProvider { get; set; }
        public bool EnableIncomingWebhooks { get; set; }
        public bool EnableOutgoingWebhooks { get; set; }
        public bool EnablePostUsernameOverride { get; set; }
        public bool EnablePostIconOverride { get; set; }
        public bool EnableTesting { get; set; }
        public bool EnableDeveloper { get; set; }
        public bool EnableSecurityFixAlert { get; set; }
    }
}