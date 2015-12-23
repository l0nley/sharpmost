namespace Mattermost.Client
{
    public class LdapSettings
    {
        public bool Enable { get; set; }
        public string LdapServer { get; set; }
        public int LdapPort { get; set; }
        // ReSharper disable once InconsistentNaming
        public string BaseDN { get; set; }
        public string BindUsername { get; set; }
        public string BindPassword { get; set; }
        public string FirstNameAttribute { get; set; }
        public string LastNameAttribute { get; set; }
        public string EmailAttribute { get; set; }
        public string UsernameAttribute { get; set; }
        public string IdAttribute { get; set; }
        public int QueryTimeout { get; set; }
    }
}