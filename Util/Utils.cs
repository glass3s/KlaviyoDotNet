using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace KlaviyoDotNet.Util
{
    public static class Utils
    {
        /// <summary>
        /// Serialize an object to JSON.
        /// </summary>
        /// <returns>Returns a string representing the serialized object.</returns>
        public static string ToJSON(this object obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj);
            return jsonString;
        }

        /// <summary>
        /// Get the object from JSON.
        /// </summary>
        /// <typeparam name="T">The class type to be deserialized.</typeparam>
        /// <param name="json">The serialization string.</param>
        /// <returns>Returns the object deserialized from the JSON string.</returns>
        public static T FromJSON<T>(this string stringObj)  where T : class
        {
            T obj = JsonConvert.DeserializeObject<T>(stringObj);
            return obj;
        }
    }
}
