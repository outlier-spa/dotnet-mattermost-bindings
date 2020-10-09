using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Outlier.Mattermost.Models
{

    public class EventBase
    {

        [JsonPropertyName("event")]
        public string Event { get; set; }


        [JsonPropertyName("data")]
        public object Data { get; set; }


        [JsonPropertyName("broadcast")]
        public Broadcast Broadcast { get; set; }

    }

}
