using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Outlier.Mattermost.Models
{
    
    public class Attachment
    {

		public Attachment()
		{

		}

		public Attachment(Action action)
		{
            this.Actions = new List<Action>() { action };
		}


        /// <summary>
        /// https://docs.mattermost.com/developer/interactive-messages.html
        /// </summary>
        [JsonPropertyName("actions")]
        public List<Action> Actions { get; set; }

        /// <summary>
        /// A required plain-text summary of the attachment. This is used in notifications,
        /// and in clientsthat don’t support formatted text (e.g. IRC).
        /// </summary>
        [JsonPropertyName("fallback")]
        public string Fallback { get; set; }

        /// <summary>
        /// A hex color code that will be used as the left border color for the attachment.
        /// If not specified,it will default to match the left hand sidebar header background color.
        /// </summary>
        [JsonPropertyName("color")]
        public string Color { get; set; }

        /// <summary>
        /// An optional line of text that will be shown above the attachment.
        /// </summary>
        [JsonPropertyName("pretext")]
        public string Pretext { get; set; }

        /// <summary>
        /// The text to be included in the attachment. It can be formatted using Markdown.
        /// For long texts, the message is collapsed and a “Show More” link is added to expand the message.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }


        /// <summary>
        /// An optional name used to identify the author. It will be included in a small section at the top of the attachment.
        /// </summary>
        [JsonPropertyName("author_name")]
        public string AuthorName { get; set; }

        /// <summary>
        /// An optional URL used to hyperlink the author_name. If no author_name is specified, this field does nothing.
        /// </summary>
        [JsonPropertyName("author_link")]
        public string AuthorLink { get; set; }

        /// <summary>
        /// An optional URL used to display a 16x16 pixel icon beside the author_name.
        /// </summary>
        [JsonPropertyName("author_icon")]
        public string AuthorIcon { get; set; }


        /// <summary>
        /// An optional title displayed below the author information in the attachment.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// An optional URL used to hyperlink the title. If no title is specified, this field does nothing.
        /// </summary>
        [JsonPropertyName("title_link")]
        public string TitleLink { get; set; }


        /// <summary>
        /// Fields can be included as an optional array within attachments, and are used to
        /// display information in a table format inside the attachment.
        /// </summary>
        [JsonPropertyName("fields")]
        public List<Field> Fields { get; set; }


        /// <summary>
        /// An optional URL to an image file (GIF, JPEG, PNG, BMP, or SVG) that is displayed inside a message attachment.
        /// </summary>
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }



        /// <summary>
        /// An optional URL to an image file (GIF, JPEG, PNG, BMP, or SVG) that is displayed as a
        /// 75x75 pixel thumbnail on the right side of an attachment. We recommend using an image that is
        /// already 75x75 pixels, but larger images will be scaled down with the aspect ratio maintained.
        /// </summary>
        [JsonPropertyName("thumb_url")]
        public string ThumbUrl { get; set; }

        /// <summary>
        /// An optional line of text that will be displayed at the bottom of the attachment.
        /// Footers with more than 300 characters will be truncated with an ellipsis (…).
        /// </summary>
        [JsonPropertyName("footer")]
        public string Footer { get; set; }


        /// <summary>
        /// An optional URL to an image file (GIF, JPEG, PNG, BMP, or SVG) that
        /// is displayed as a 16x16 pixel thumbnail before the footer text.
        /// </summary>
        [JsonPropertyName("footer_icon")]
        public string FooterIcon { get; set; }

    }
}
