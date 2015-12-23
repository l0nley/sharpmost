namespace Mattermost.Client
{
    public class Config
    {
        public ServiceSettings ServiceSettings { get; set; }

        public TeamSettings TeamSettings { get; set; }

        public SqlSettings SqlSettings { get; set; }

        public LogSettings LogSettings { get; set; }

        public FileSettings FileSettings { get; set; }

        public EmailSettings EmailSettings { get; set; }

        public RateLimitSettings RateLimitSettings { get; set; }

        public PrivacySettings PrivacySettings { get; set; }

        public SupportSettings SupportSettings { get; set; }

        public SSOSettings GitLabSettings  { get; set; }

        public SSOSettings GoogleSettings { get; set; }

        public LdapSettings LdapSettings { get; set; }
    }
}