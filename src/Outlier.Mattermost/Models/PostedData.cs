using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Outlier.Mattermost.Models
{

    public class PostedData
    {

        public List<string> MentionsIds =>
            string.IsNullOrWhiteSpace(this.Mentions) ? null : JsonSerializer.Deserialize<List<string>>(this.Mentions);

        public Post PostContent => JsonSerializer.Deserialize<Post>(this.Post);


        /// <summary>
        /// @usuario para usuarios, nombre puede tener espacios
        /// </summary>
        [JsonPropertyName("channel_display_name")]
        public string ChannelDisplayName { get; set; }


        /// <summary>
        /// Nombre codificado del canal, sin espacios, ids para canales directos
        /// </summary>
        [JsonPropertyName("channel_name")]
        public string ChannelName { get; set; }


        [JsonPropertyName("channel_type")]
        public string ChannelType { get; set; }


        [JsonPropertyName("mentions")]
        public string Mentions { get; set; }


        [JsonPropertyName("post")]
        public string Post { get; set; }


        /// <summary>
        /// @usuario
        /// </summary>
        [JsonPropertyName("sender_name")]
        public string SenderName { get; set; }


        [JsonPropertyName("team_id")]
        public string TeamId { get; set; }

    }

}
