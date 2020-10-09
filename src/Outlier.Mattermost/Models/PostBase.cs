using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Outlier.Mattermost.Models
{

    public class PostBase
    {

        /// <summary>
        /// The message contents, can be formatted with Markdown
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }


        /// <summary>
        /// A list of file IDs to associate with the post. Note that posts
        /// are limited to 5 files maximum. Please use additional posts for more files.
        /// </summary>
        [JsonPropertyName("file_ids")]
        public List<string> FileIds { get; set; }


        /// <summary>
        /// A general JSON property bag to attach to the post
        /// </summary>
        [JsonPropertyName("props")]
        public Props Props { get; set; }



        public PostBase() { }

        public PostBase(string message)
        {
            this.Message = message;
        }

        public PostBase(string message, Attachment attachment) : this(message)
        {
            this.Props = new Props();
            this.Props.Attachments = new List<Attachment>() { attachment };
        }


    }

    public class Props
    {

        [JsonPropertyName("attachments")]
        public List<Attachment> Attachments { get; set; }

    }

}
