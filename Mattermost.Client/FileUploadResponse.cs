using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class FileUploadResponse
    {
        [JsonProperty("filenames")]
        public string[] Filenames { get; set; }
        [JsonProperty("client_ids")]
        public string[] ClientIds { get; set; }
    }
}