namespace Mattermost.Client
{
    public class SqlSettings
    {
        public string DriverName { get; set; }
        public string DataSource { get; set; }
        public string[] DataSourceReplicas { get; set; }
        public int MaxIdleConns { get; set; }
        public int MaxOpenConns { get; set; }
        public bool Trace { get; set; }
        public string AtRestEncryptKey { get; set; }
    }
}