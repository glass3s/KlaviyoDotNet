using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlaviyoDotNet.Components
{
    public class Lists : Component
    {
        [JsonProperty(PropertyName = "object")]
        public string _object { get; set; }
        [JsonProperty]
        public string id { get; set; }
        [JsonProperty]
        public string name { get; set; }
        [JsonProperty]
        public string list_type { get; set; }
        [JsonProperty]
        public DateTime created { get; set; }
        [JsonProperty]
        public DateTime updated { get; set; }
        [JsonProperty]
        public int person_count { get; set; }
    }
}
