// ReSharper disable InconsistentNaming
namespace Mattermost.Client
{
    public class SSOSettings
    {
        public bool Enable { get; set; }
        public string Secret { get; set; }
        public string Id { get; set; }
        public string Scope { get; set; }
        public string AuthEndpoint { get; set; }
        public string TokenEndpoint { get; set; }
        public string UserApiEndpoint { get; set; }
    }
}