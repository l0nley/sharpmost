using Newtonsoft.Json;

namespace Mattermost.Client
{
    public class Post
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("create_at")]
        public long CreateAt { get; set; }
        [JsonProperty("update_at")]
        public long UpdateAt { get; set; }
        [JsonProperty("delete_at")]
        public long DeleteAt { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("root_id")]
        public string RootId { get; set; }
        [JsonProperty("parent_id")]
        public string ParentId { get; set; }
        [JsonProperty("original_id")]
        public string OriginalId { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("props")]
        public string[] Props { get; set; }
        [JsonProperty("hashtags")]
        public string Hashtags { get; set; }
        [JsonProperty("filenames")]
        public string[] Filenames { get; set; }
        [JsonProperty("pending_post_id")]
        public string PendingPostId { get; set; }
        [JsonProperty("channel_id")]
        public string ChannelId { get; set; }
    }
}