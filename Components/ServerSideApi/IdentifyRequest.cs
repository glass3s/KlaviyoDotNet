using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KlaviyoDotNet.Components
{
    [DataContract]
    [Serializable]
    public class IdentifyRequest : Component
    {
        [JsonProperty]
        public string token { get; set; }
        [JsonProperty]
        public Dictionary<string, object> properties { get; set; }
    }
}
