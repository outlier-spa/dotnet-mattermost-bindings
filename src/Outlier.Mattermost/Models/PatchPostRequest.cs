using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Outlier.Mattermost.Models
{

    public class PatchPostRequest : PostBase
    {

        /// <summary>
        /// Set to true to pin the post to the channel it is in
        /// </summary>
        [JsonPropertyName("is_pinned")]
        public bool? IsPinned { get; set; }


        public PatchPostRequest(PostBase b)
        {
            this.FileIds = b.FileIds;
            this.Message = b.Message;
            this.Props = b.Props;
        }

    }

}
