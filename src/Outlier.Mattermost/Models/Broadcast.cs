using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Outlier.Mattermost.Models
{

    public class Broadcast
    {

        //[JsonPropertyName("omit_users")]
        //public List<string> OmitUsers { get; set; }


        [JsonPropertyName("user_id")]
        public string UserId { get; set; }


        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; }


        [JsonPropertyName("team_id")]
        public string TeamId { get; set; }

    }
}
