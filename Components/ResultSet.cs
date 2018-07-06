using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace KlaviyoDotNet.Components
{
    public class ResultSet<T> where T : Component
    {
        [JsonProperty(PropertyName = "data")]
        private List<T> data;

        /// <summary>
        /// Gets or sets the array of data objects returned.
        /// </summary>
        public IList<T> Results
        {
            get { return data; }
            set { data = value == null ? null : value.ToList(); }
        }

        /// <summary>
        /// Gets or sets the object link.
        /// </summary>
        [JsonProperty(PropertyName = "object")]
        public string _object { get; set; }

        /// <summary>
        /// Gets or sets the page_size link.
        /// </summary>
        [JsonProperty(PropertyName = "page_size")]
        public int page_size { get; set; }

        /// <summary>
        /// Gets or sets the start link.
        /// </summary>
        public int start { get; set; }

        /// <summary>
        /// Gets or sets the end link.
        /// </summary>
        public int end { get; set; }

        /// <summary>
        /// Gets or sets the total link.
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// Gets or sets the total link.
        /// </summary>
        public int page { get; set; }
    }
}
