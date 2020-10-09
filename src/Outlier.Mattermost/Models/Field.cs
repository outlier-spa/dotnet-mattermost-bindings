using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Outlier.Mattermost.Models
{

    public class Field
    {

        /// <summary>
        /// A title shown in the table above the value. As of v5.14 a title will render emojis properly.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }


        /// <summary>
        /// The text value of the field. It can be formatted using Markdown.
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }


        /// <summary>
        /// Optionally set to true or false (boolean) to indicate whether the value is short enough to be displayed beside other values.
        /// </summary>
        [JsonPropertyName("short")]
        public bool Short { get; set; }

    }

}
