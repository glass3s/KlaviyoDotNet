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
    public class Person : Component
    {
        public string _object { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "$email")]
        public string email { get; set; }
        [DataMember(Name = "id")]
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string organization { get; set; }
        public string title { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public string timezone { get; set; }
        public string phone_number { get; set; }
    }
}
