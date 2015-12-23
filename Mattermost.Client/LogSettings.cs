namespace Mattermost.Client
{
    public class LogSettings
    {
        public bool EnableConsole { get; set; }
        public string ConsoleLevel { get; set; }
        public bool EnableFile { get; set; }
        public string FileLevel { get; set; }
        public string FileFormat { get; set; }
        public string FileLocation { get; set; }
    }
}