namespace Mattermost.Client
{
    public class FileSettings
    {
        public string DriverName { get; set; }
        public string Directory { get; set; }
        public bool EnablePublicLink { get; set; }
        public string PublicLinkSalt { get; set; }
        public int ThumbnailWidth { get; set; }
        public int ThumbnailHeight { get; set; }
        public int PreviewWidth { get; set; }
        public int PreviewHeight { get; set; }
        public int ProfileWidth { get; set; }
        public int ProfileHeight { get; set; }
        public string InitialFont { get; set; }
        public string AmazonS3AccessKeyId { get; set; }
        public string AmazonS3SecretAccessKey { get; set; }
        public string AmazonS3Bucket { get; set; }
        public string AmazonS3Region { get; set; }
    }
}