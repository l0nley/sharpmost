// ReSharper disable InconsistentNaming
namespace Mattermost.Client
{
    public static class Constants
    {
        public const string HEADER_REQUEST_ID = "X-Request-ID";
        public const string HEADER_VERSION_ID = "X-Version-ID";
        public const string HEADER_ETAG_SERVER = "ETag";
        public const string HEADER_ETAG_CLIENT = "If-None-Match";
        public const string HEADER_FORWARDED = "X-Forwarded-For";
        public const string HEADER_REAL_IP = "X-Real-IP";
        public const string HEADER_FORWARDED_PROTO = "X-Forwarded-Proto";
        public const string HEADER_TOKEN = "token";
        public const string HEADER_BEARER = "BEARER";
        public const string HEADER_AUTH = "Authorization";
        public const string HEADER_MM_SESSION_TOKEN_INDEX = "X-MM-TokenIndex";
        public const string SESSION_TOKEN_INDEX = "session_token_index";
        public const string API_URL_SUFFIX = "/api/v1";
        public const string SESSION_COOKIE_TOKEN = "MMTOKEN";
    }
}