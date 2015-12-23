using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mattermost.Client
{
    public class Client
    {
        public string Url { get;  }
        public string ApiUrl { get;  }
        private readonly HttpClient _httpClient;
        private readonly CookieContainer _container;
        public string AuthToken { get; set; }
        public string AuthType { get; set; }

        public HttpClientHandler Handler { get; set; }

        public Client(string url)
        {
            Url = url;
            ApiUrl = url + Constants.API_URL_SUFFIX;
            AuthType = string.Empty;
            AuthToken = string.Empty;
            _container = new CookieContainer();
            var handler = new HttpClientHandler { CookieContainer = _container };
            _httpClient = new HttpClient(handler);
        }

     

        public Task<Result<object>> SignupTeam(string email, string displayName)
        {
            return DoApiPost<object>("/teams/signup", new {email, display_name = displayName});
        }

        public Task<Result<TeamSignup>> CreateTeamFromSignup(TeamSignup signup)
        {
            return DoApiPost<TeamSignup>("/teams/create_from_signup", signup.ToJson());
        }

        public Task<Result<Team>> CreateTeam(Team team)
        {
            return DoApiPost<Team>("/teams/create", team);
        }

        public Task<Result<Dictionary<string,Team>>> GetAllTeams()
        {
            return DoApiGet<Dictionary<string, Team>>("/teams/all", "", "");
        }

        public Task<Result<Team>> GetMyTeam(string etag)
        {
            return DoApiGet<Team>("/teams/me", null, etag);
        }

        public async Task<Result<bool>> FindTeamByName(string teamName, bool allServers)
        {
            var response = await DoStringApiPost("/teams/find_team_by_name", new {name = teamName, all = allServers}.ToJson());
            return await Result<bool>.CreateResult(response, bool.Parse);
        }

        public Task<Result<Dictionary<string,Team>>> FindTeams(string email)
        {
            return DoApiPost<Dictionary<string, Team>>("/teams/find_teams", new {email});
        }

        public Task<Result<string[]>> FindTeamsSendEmail(string email)
        {
            return DoApiPost<string[]>("/teams/email_teams", new {email});
        }

        public Task<Result<Invites>> InviteMembers(Invites invites)
        {
            return DoApiPost<Invites>("/teams/invite_members", invites);
        }

        public Task<Result<object>> UpdateTeam(Team team)
        {
            return DoApiPost<object>("/teams/update", team);
        }

        public Task<Result<User>> CreateUser(User user)
        {
            return DoApiPost<User>("/users/create", user);
        }

        public Task<Result<User>> CreateUserFromSignup(User user, string data, string hash)
        {
            var edata = Uri.EscapeUriString(data);
            return DoApiPost<User>($"/users/create?d={edata}&h={hash}", user);
        }

        public Task<Result<User>> GetUser(string id, string etag)
        {
            return DoApiGet<User>($"/users/{id}", null, etag);
        }

        public Task<Result<User>> GetMe(string etag)
        {
            return DoApiGet<User>("/users/me", null, etag);
        }

        public Task<Result<User>> UpdateUser(User user)
        {
            return DoApiPost<User>("/users/update", user);
        }

        public Task<Result<User>> UpdateUserRoles(Dictionary<string,string> map)
        {
            return DoApiPost<User>("/users/update", map);
        }

        public Task<Result<User>> UpdateActive(string userId, bool active)
        {
            return DoApiPost<User>("/users/update_active", new {user_id = userId, active});
        }

        public Task<Result<User>> UpdateUserNotify(Dictionary<string, string> map)
        {
            return DoApiPost<User>("/users/update_notify", map);
        }

        public Task<Result<User>> UpdateUserPassword(string userId, string currentPassword, string newPassword)
        {
            return DoApiPost<User>("/users/newpassword",
                new {user_id = userId, current_password = currentPassword, new_password = newPassword});
        }

        public Task<Result<object>> SendPasswordReset(Dictionary<string,string> map )
        {
            return DoApiPost<object>("/users/send_password_reset", map);
        }

        public Task<Result<object>> ResetPassword(Dictionary<string, string> map)
        {
            return DoApiPost<object>("/users/reset_password", map);
        }

        public Task<Result<object>> GetStatuses(string[] users)
        {
            return DoApiPost<object>("/users/status", users);
        }
        
        public Task<Result<Dictionary<string, User>>> GetProfiles(string teamId, string etag)
        {
            return DoApiGet<Dictionary<string, User>>($"/users/profiles/{teamId}", null, string.Empty);
        }

        public Task<Result<User>> LoginById(string id, string password)
        {
            return Login(new {id, password});
        }

        public Task<Result<User>> LoginByEmail(string name, string email, string password)
        {
            return Login(new {name, email, password});
        }

        public Task<Result<User>> LoginByEmailWithDevice(string name, string email, string password, string deviceId)
        {
            return Login(new {name, email, password, device_id = deviceId});
        }

        public async Task<Result<object>> Logout()
        {
            var result = await DoApiPost<object>("/users/logout", null);
            AuthToken = null;
            AuthType = Constants.HEADER_BEARER;
            return result;
        }

        public void SetOAuthToken(string token)
        {
            AuthToken = token;
            AuthType = Constants.HEADER_BEARER;
        }


        public void ClearOAuthToken()
        {
            AuthToken = null;
            AuthType = Constants.HEADER_BEARER;
        }

        public Task<Result<object>>  RevokeSession(string sessionAltId)
        {
            return DoApiPost<object>("/users/revoke_session", new {id = sessionAltId});
        }

        public Task<Result<Session[]>> GetSessions(string id)
        {
            return DoApiGet<Session[]>($"/users/{id}/sessions", null, null);
        }

        public Task<Result<CommandDefinition>> Command(string channelId, string command, bool suggest)
        {
            return DoApiPost<CommandDefinition>("/command", new {command, channelId, suggest});
        }

        public Task<Result<Audit[]>> GetAudits(string id, string etag)
        {
            return DoApiGet<Audit[]>($"/users/{id}/audits", null, etag);
        }

        public Task<Result<string[]>> GetLogs()
        {
            return DoApiGet<string[]>("/admin/logs", null, null);
        }

        public Task<Result<object>> GetClientProperties()
        {
            return DoApiGet<object>("/admin/client_props", null, null);
        }

        public Task<Result<Config>> GetConfig()
        {
            return DoApiGet<Config>("/admin/config", null, null);
        }

        public Task<Result<Config>> SaveConfig(Config config)
        {
            return DoApiPost<Config>("/admin/save_config", config);
        }

        public Task<Result<object>> TestEmail(Config config)
        {
            return DoApiPost<object>("/admin/test_email", config);
        }

        public Task<Result<AnalyticsRow[]>> GetAnalytics(string teamId, string name)
        {
            return DoApiGet<AnalyticsRow[]>($"/admin/analytics/{teamId}/{name}", null, null);
        }

        public Task<Result<Channel>> CreateChannel(Channel channel)
        {
            return DoApiPost<Channel>("/channels/create", channel);
        }

        public Task<Result<Channel>> CreateDirectChannel(Dictionary<string, string> map)
        {
            return DoApiPost<Channel>("/channels/create_direct", map);
        }

        public Task<Result<Channel>> UpdateChannel(Channel channel)
        {
            return DoApiPost<Channel>("/channels/update", channel);
        }

        public Task<Result<Channel>> UpdateChannelHeader(Dictionary<string, string> map)
        {
            return DoApiPost<Channel>("/channels/update_header", map);
        }

        public Task<Result<Channel>> UpdateChannelPurpose(Dictionary<string, string> map)
        {
            return DoApiPost<Channel>("/channels/update_purpose", map);
        }

        public Task<Result<object>> UpdateNotifyProps(Dictionary<string, string> map)
        {
            return DoApiPost<object>("/channels/update_notify_props", map);
        }

        public Task<Result<ChannelList>> GetChannels(string etag)
        {
            return DoApiGet<ChannelList>("/channels/", null, etag);
        }

        public Task<Result<ChannelData>> GetChannel(string id, string etag)
        {
            return DoApiGet<ChannelData>($"/channels/{id}/", null, etag);
        }

        public Task<Result<ChannelCounts>> GetChannelCounts(string etag)
        {
            return DoApiGet<ChannelCounts>("/channels/counts", null, etag);
        }

        public Task<Result<object>> JoinChannel(string id)
        {
            return DoApiPost<object>($"/channels/{id}/join", null);
        }

        public Task<Result<object>> LeaveChannel(string id)
        {
            return DoApiPost<object>($"/channels/{id}/leave", null);
        }

        public Task<Result<object>> DeleteChannel(string id)
        {
            return DoApiPost<object>($"/channels/{id}/delete", null);
        }

        public Task<Result<object>> AddChannelMember(string id, string userId)
        {
            return DoApiPost<object>($"/channels/{id}/add", new {user_id = userId});
        }

        public Task<Result<object>> RemoveChannelMember(string id, string userId)
        {
            return DoApiPost<object>($"/channels/{id}/remove", new { user_id = userId });
        }

        public Task<Result<object>> UpdateLastViewedAt(string channelId)
        {
            return DoApiPost<object>($"/channels/{channelId}/update_last_viewed_at", null);
        }

        public Task<Result<ChannelExtra>> GetChannelExtraInfo(string id, string etag)
        {
            return DoApiGet<ChannelExtra>($"/channels/{id}/extra_info", null, etag);
        }

        public Task<Result<Post>> CreatePost(Post post)
        {
            return DoApiPost<Post>($"/channels/{post.ChannelId}/create", post);
        }

        public Task<Result<Post>> UpdatePost(Post post)
        {
            return DoApiPost<Post>($"/channels/{post.ChannelId}/create", post);
        }

        public Task<Result<PostList>> GetPosts(string channelId, int offset, int limit, string etag)
        {
            return DoApiGet<PostList>($"/channels/{channelId}/posts/{offset}/{limit}", null, etag);
        }
        public Task<Result<PostList>> GetPostsSince(string channelId, long time)
        {
            return DoApiGet<PostList>(string.Format("/channels/{0}/posts/{1}", channelId, time), null,null);
        }

        public Task<Result<PostList>> GetPostsBefore(string channelId, string postId, int offset, int limit, string etag)
        {
            return DoApiGet<PostList>($"/channels/{channelId}/post/{postId}/before/{offset}/{limit}", null, etag);
        }


        public Task<Result<PostList>> GetPostsAfter(string channelId, string postId, int offset, int limit, string etag)
        {
            return DoApiGet<PostList>($"/channels/{channelId}/post/{postId}/after/{offset}/{limit}", null, etag);
        }

        public Task<Result<PostList>> GetPosts(string channelId, string postId, string etag)
        {
            return DoApiGet<PostList>($"/channels/{channelId}/post/{postId}", null, etag);
        }

        public Task<Result<PostList>> DeletePost(string channelId, string postId)
        {
            return DoApiPost<PostList>($"/channels/{channelId}/post/{postId}/delete", null);
        }

        public Task<Result<PostList>> SearchPosts(string terms)
        {
            var edata = Uri.EscapeUriString(terms);
            return DoApiGet<PostList>($"/posts/search?terms={edata}", null, null);
        }

        public async Task<Result<FileUploadResponse>> UploadFile(string url, Stream data, string contentType)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, ApiUrl + url)
            {
                Content = new StreamContent(data)
            };
            request.Headers.Add("Content-Type", contentType);
            if (string.IsNullOrEmpty(AuthToken) == false)
            {
                request.Headers.Add(Constants.HEADER_AUTH, $"{AuthType} {AuthToken}");
            }

            var response = await _httpClient.SendAsync(request);

            return await Result<FileUploadResponse>.CreateResult(response, _ =>_.FromString<FileUploadResponse>());
        }

        public async Task<Result<byte[]>> GetFile(string url, bool isFullUrl)
        {
            var eurl = isFullUrl ? url : ApiUrl + url;
            var request = new HttpRequestMessage(HttpMethod.Get, eurl);
            if (string.IsNullOrEmpty(AuthToken) == false)
            {
                request.Headers.Add(Constants.HEADER_AUTH, $"{AuthType} {AuthToken}");
            }

            var response = await _httpClient.SendAsync(request);
            var bytes = await response.Content.ReadAsByteArrayAsync();
            return new Result<byte[]>
            {
                RequestId = response.Headers.GetValues(Constants.HEADER_REQUEST_ID).FirstOrDefault(),
                Etag = response.Headers.GetValues(Constants.HEADER_ETAG_SERVER).FirstOrDefault(),
                Data = bytes
            };
        }

        public Task<Result<object>> GetFileInfo(string url)
        {
            return DoApiGet<object>("/files/get_info" + url, null, null);
        }

        public Task<Result<object>> GetPublicLink(Dictionary<string, string> map)
        {
            return DoApiPost<object>("/files/get_public_link", map);
        }

        public Task<Result<OAuthApp>> RegisterApp(OAuthApp app)
        {
            return DoApiPost<OAuthApp>("/oauth/register", app);
        }

        public Task<Result<object>> AllowOAuth(string responseType, string clientId, string redirect, string scope,
            string state)
        {
            var uri =
                $"/oauth/allow?response_type={responseType}&client_id={clientId}&redirect_uri={Uri.EscapeUriString(redirect)}&scope={scope}&state={Uri.EscapeUriString(state)}";
            return DoApiGet<object>(uri, null, null);
        }

        public async Task<Result<AccessResponse>> GetAccessToken(Dictionary<string,string> values)
        {
            var response =
                await
                    DoPost("/oauth/access_token", string.Join("\n", values.Select(_ => _.Key + "=" + _.Value)),
                        "application/x-www-form-urlencoded");
            return await Result<AccessResponse>.CreateResult(response, _ => _.FromString<AccessResponse>());
        }

        public Task<Result<IncomingWebHook>> CreateIncomingWebhook(IncomingWebHook hook)
        {
            return DoApiPost<IncomingWebHook>("/hooks/incoming/create", hook);
        }

        public async Task<Result<object>> PostToWebhook(string id, string payload)
        {
            var response = await DoPost($"/hooks/{id}", payload, "application/x-www-form-urlencoded");
            return await Result<object>.CreateResult(response, _ => _);
        }

        public Task<Result<IncomingWebHook>> DeleteIncomingWebhook(Dictionary<string,string> map)
        {
            return DoApiPost<IncomingWebHook>("/hooks/incoming/delete", map);
        }

        public Task<Result<IncomingWebHook[]>> ListIncomingWebhooks()
        {
            return DoApiGet<IncomingWebHook[]>("/hooks/incoming/list", null, null);
        }

        public Task<Result<Preference[]>> GetAllPreferences()
        {
            return DoApiGet<Preference[]>("/preferences/", null, null);
        }

        public Task<Result<Preference[]>> SetPreferences(Preference[] preferences)
        {
            return DoApiPost<Preference[]>("/preferences/save", preferences);
        }

        public Task<Result<Preference[]>> GetPreferenceCategory(string category)
        {
            return DoApiGet<Preference[]>($"/preferences/{category}", null, null);
        }

        public Task<Result<OutgoingWebHook>> CreateOutgoingWebhook(OutgoingWebHook hook)
        {
            return DoApiPost<OutgoingWebHook>("/hooks/outgoing/create", hook);
        }

        public Task<Result<object>> DeleteOutgoingWebhook(Dictionary<string,string> map)
        {
            return DoApiPost<object>("/hooks/outgoing/delete", map);
        }

        public Task<Result<OutgoingWebHook[]>> ListOutgoingWebhooks()
        {
            return DoApiGet<OutgoingWebHook[]>("/hooks/outgoing/list", null, null);
        }

        public Task<Result<OutgoingWebHook>> RegenOutgoingWebhookToken(Dictionary<string, string> map)
        {
            return DoApiPost<OutgoingWebHook>("/hooks/outgoing/regen_token", map);
        }

        private async Task<Result<User>> Login(object data)
        {
            var response = await DoStringApiPost("/users/login", data.ToJson());
            AuthToken = response.Headers.GetValues(Constants.HEADER_TOKEN).FirstOrDefault();
            AuthType = Constants.HEADER_BEARER;
            var sessionToken = GetCookie(Constants.SESSION_COOKIE_TOKEN);
            if (AuthToken != sessionToken)
            {
                throw new InvalidOperationException("Authentication tokens didn't match");
            }

            return await Result<User>.CreateResult(response, _ => _.FromString<User>());
        }

        private async Task<Result<T>> DoApiPost<T>(string url, object data)
        {
            var response = await DoStringApiPost(url, data.ToJson());
            return await Result<T>.CreateResult(response, _ => _.FromString<T>());
        }

        private async Task<Result<T>> DoApiGet<T>(string url, object data, string etag)
        {
            var response = await DoStringApiGet(url, data?.ToJson(), etag);
            return await Result<T>.CreateResult(response, _ => _.FromString<T>());
        }

        private Task<HttpResponseMessage> DoPost(string url, string data, string contentType)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, Url + url);
            message.Headers.Add("Content-Type", contentType);
            message.Content = new StringContent(data);
            return _httpClient.SendAsync(message);
        }

        private Task<HttpResponseMessage> DoStringApiPost(string url, string data)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, ApiUrl + url);
            if (string.IsNullOrEmpty(AuthToken) == false)
            {
                message.Headers.Add(Constants.HEADER_AUTH, AuthType + " " + AuthToken);
            }
            message.Content = new StringContent(data);
            return _httpClient.SendAsync(message);
        }

        private Task<HttpResponseMessage> DoStringApiGet(string url, string data, string etag)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, ApiUrl + url);
            if (string.IsNullOrEmpty(AuthToken) == false)
            {
                message.Headers.Add(Constants.HEADER_AUTH, AuthType + " " + AuthToken);
            }
            if (string.IsNullOrEmpty(etag) == false)
            {
                message.Headers.Add(Constants.HEADER_ETAG_CLIENT, etag);
            }
            message.Content = new StringContent(data);

            return _httpClient.SendAsync(message);
        }


        private string GetCookie(string name)
        {
            return _container.GetCookies(new Uri(Url)).Cast<Cookie>().FirstOrDefault(_ => _.Name == name).Value;
        }
    }
}