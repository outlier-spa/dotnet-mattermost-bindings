using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Outlier.Mattermost.Models
{

    public class Post : PostBase
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }


        [JsonPropertyName("user_id")]
        public string UserId { get; set; }


        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; }


        [JsonPropertyName("root_id")]
        public string RootId { get; set; }


        [JsonPropertyName("parent_id")]
        public string ParentId { get; set; }


        [JsonPropertyName("original_id")]
        public string OriginalId { get; set; }


        [JsonPropertyName("type")]
        public string Type { get; set; }

    }

}
