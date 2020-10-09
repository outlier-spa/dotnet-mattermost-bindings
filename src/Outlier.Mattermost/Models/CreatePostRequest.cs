using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Outlier.Mattermost.Models
{

    public class CreatePostRequest : PostBase
    {

        /// <summary>
        /// The channel ID to post in
        /// </summary>
        [JsonPropertyName("channel_id")]
        public string ChannelId { get; set; }


        /// <summary>
        /// The post ID to comment on
        /// </summary>
        [JsonPropertyName("root_id")]
        public string RootId { get; set; }


        public CreatePostRequest()
        {

        }


        public CreatePostRequest(PostBase b)
        {
            this.FileIds = b.FileIds;
            this.Message = b.Message;
            this.Props = b.Props;
        }


    }

}
