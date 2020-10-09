using Microsoft.Extensions.Options;
using Outlier.Mattermost.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Websocket.Client;
using System.Net.WebSockets;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace Outlier.Mattermost
{

    /// <summary>
    /// Mattermost client object
    /// </summary>
    public class MattermostClient : IDisposable
    {

        MattermostClientConfiguration settings;
        HttpClient http;
        WebsocketClient ws;

        JsonSerializerOptions jsonOptions;


        public MattermostClient(IOptions<MattermostClientConfiguration> settings) : this(settings.Value) { }

        public MattermostClient(MattermostClientConfiguration settings)
        {
            this.settings = settings;
            http = new HttpClient();
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.settings.Token);

            jsonOptions = new JsonSerializerOptions()
            {
                IgnoreNullValues = true
            };
        }

        string GetUri(string action) => $"{settings.MattermostV4Endpoint.TrimEnd('/')}{action}";


        /// <summary>
        /// Enables websocket client channel
        /// </summary>
        /// <param name="ReconnectTimeout">Time range in ms, how long to wait before reconnecting if no message comes from the server</param>
        public Task EnableWebSocketConnection(int ReconnectTimeout = 30)
        {
            var url = new Uri(GetUri("/websocket").Replace("https://", "ws://"));

            // configure client web socket options
            var factory = new Func<ClientWebSocket>(() => new ClientWebSocket 
                { Options = { KeepAliveInterval = TimeSpan.FromSeconds(10) } });

            ws?.Dispose();
            ws = new WebsocketClient(url, factory);

            ws.ReconnectTimeout = TimeSpan.FromSeconds(30);

            ws.ReconnectionHappened.Subscribe(info =>
            {
                WebSocketAuthChallenge auth = new WebSocketAuthChallenge(settings.Token);
                ws.Send(JsonSerializer.Serialize(auth));
            });

            return ws.Start();
        }


        /// <summary>
        /// Subscribe to all events coming through websocket channel
        /// </summary>
        public void SubscribeToWsEvent(Action<string> nextMessage)
        {
            ws.MessageReceived.Subscribe(msg => nextMessage(msg.Text));
        }


        /// <summary>
        /// Sends a message through websocket channel
        /// </summary>
        /// <param name="message"></param>
        public void SendEventTroughWs(string message)
		{
            ws.Send(message);
		}


        /// <summary>
        /// Subscribe to post event through websocket channel
        /// </summary>
        public void SubscribeToPostEvent(Action<PostEvent> nextPost)
        {
            ws.MessageReceived.Subscribe(msg =>
            {
                var eb = JsonSerializer.Deserialize<EventBase>(msg.Text);

                if (eb?.Event == "posted")
                {
                    var posted = JsonSerializer.Deserialize<PostEvent>(msg.Text);

                    nextPost(posted);
                }
            });
        }



        /// <summary>
        /// Gets information about the current user (bot?)
        /// </summary>
        public Task<User> GetMe()
        {
            return GetUserById("me");
        }

        public Task<User> GetUserById(string userId)
        {
            return http.GetFromJsonAsync<User>(GetUri($"/users/{userId}"));
        }

        public Task<User> GetUserByUsername(string username)
        {
            return http.GetFromJsonAsync<User>(GetUri($"/users/username/{username}"));
        }


        public Task<List<User>> GetUsers(int? perPage = null, string inChannel = "", bool? active = null)
        {
            string queryParams = "?";

            if (perPage.HasValue) queryParams += $"per_page={perPage}&";
            if (!string.IsNullOrWhiteSpace(inChannel)) queryParams += $"in_channel={inChannel}&";
            if (active.HasValue) queryParams += $"active={active}&";

            queryParams = queryParams[0..^1];

            return http.GetFromJsonAsync<List<User>>(GetUri("/users" + queryParams));
        }


        public Task<IdBaseModel> GetDirectChannel(string userId1, string userId2)
        {
            return GetDirectChannel(new string[] { userId1, userId2 });
        }


        public Task<IdBaseModel> GetDirectChannel(List<string> userIds)
        {
            return GetDirectChannel(userIds.ToArray());
        }


        public async Task<IdBaseModel> GetDirectChannel(string[] userIds)
        {
            return await (await http.PostAsJsonAsync(GetUri("/channels/direct"), userIds, jsonOptions))
                .Content.ReadFromJsonAsync<IdBaseModel>();
        }


        public Task<Post> GetPost(string postId)
        {
            return http.GetFromJsonAsync<Post>(GetUri($"/posts/{postId}"));
        }


        public async Task<IdBaseModel> CreatePost(CreatePostRequest request)
        {
            return await (await http.PostAsJsonAsync(GetUri("/posts"), request, jsonOptions))
                .Content.ReadFromJsonAsync<IdBaseModel>();
        }

        public Task<IdBaseModel> CreatePost(string channelId, string message, string rootId = null)
        {
            return CreatePost(channelId, new PostBase(message), rootId);
        }

        public async Task<IdBaseModel> CreatePost(string channelId, PostBase post, string rootId = null)
        {
            var request = new CreatePostRequest(post);
            request.ChannelId = channelId;
            request.RootId = rootId;

            return await (await http.PostAsJsonAsync(GetUri("/posts"), request, jsonOptions))
                .Content.ReadFromJsonAsync<IdBaseModel>();
        }


        public async Task<List<IdBaseModel>> CreatePosts(List<string> channelIds, PostBase post, string rootId = null)
        {
            return (await Task.WhenAll(from channelId in channelIds select CreatePost(channelId, post, rootId))).ToList();
        }


        public async Task<IdBaseModel> PatchPost(string postId, PatchPostRequest request)
        {
            return await (await http.PutAsJsonAsync(GetUri($"/posts/{postId}/patch"), request, jsonOptions))
                .Content.ReadFromJsonAsync<IdBaseModel>();
        }

        public async Task<IdBaseModel> PatchPost(string postId, PostBase post, bool? isPinned = null)
        {
            var request = new PatchPostRequest(post);
            request.IsPinned = isPinned;

            return await (await http.PutAsJsonAsync(GetUri($"/posts/{postId}/patch"), request, jsonOptions))
                .Content.ReadFromJsonAsync<IdBaseModel>();
        }

        public async Task<List<IdBaseModel>> PatchPosts(List<string> postIds, PostBase post, bool? isPinned = null)
        {
            return (await Task.WhenAll(from postId in postIds select PatchPost(postId, post, isPinned))).ToList();
        }


        public void Dispose()
        {
            ws?.Dispose();
        }
    }

}
