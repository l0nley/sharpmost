using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class PostList
    {
        [JsonProperty("order")]
        public string[] Order { get; set; }

        [JsonProperty("posts")]
        public Dictionary<string, Post> Posts { get; set; }
    }
}