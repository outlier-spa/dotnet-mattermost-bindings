using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Outlier.Mattermost.Models
{

    public class WebSocketAuthChallenge
    {

        [JsonPropertyName("seq")]
        public int Seq => 1;

        [JsonPropertyName("action")]
        public string Action => "authentication_challenge";

        [JsonPropertyName("data")]
        public object Data => new { this.token };



        string token = "";

        public WebSocketAuthChallenge(string token)
        {
            this.token = token;
        }

    }
}
