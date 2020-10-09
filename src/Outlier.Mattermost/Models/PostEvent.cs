using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Outlier.Mattermost.Models
{

    public class PostEvent : EventBase
    {

        public PostedData PostedData => JsonSerializer.Deserialize<PostedData>(this.Data.ToString());

    }

}
