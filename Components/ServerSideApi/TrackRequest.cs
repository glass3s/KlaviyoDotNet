using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KlaviyoDotNet.Components
{
    public class TrackRequest
    {
        public string token { get; set; }
        [JsonProperty(PropertyName = "event")]
        public string _event { get; set; }
        public customer_properties customer_properties { get; set; }
        public Dictionary<string, object> properties { get; set; }
        public long time { get; set; }
    }

    public class customer_properties
    {
        [JsonProperty(PropertyName = "$email")]
        public string email { get; set; }
    }
}
