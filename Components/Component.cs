using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;

namespace KlaviyoDotNet.Components
{
    /// <summary>
    /// Base class for components.
    /// </summary>
    [Serializable]
    [DataContract]
    public abstract class Component
    {
        /// <summary>
        /// Serialize an object to JSON.
        /// </summary>
        /// <returns>Returns a string representing the serialized object.</returns>
        //public static string ToJSON()
        //{
        //    string json = null;
        //    //using (MemoryStream ms = new MemoryStream())
        //    //{
        //    //    DataContractJsonSerializer ser = new DataContractJsonSerializer(this.GetType());
        //    //    ser.WriteObject(ms, this);
        //    //    json = Encoding.UTF8.GetString(ms.ToArray());
        //    //}
        //    json = JsonConvert.SerializeObject(this);

        //    return json;
        //}

        /// <summary>
        /// Get the object from JSON.
        /// </summary>
        /// <typeparam name="T">The class type to be deserialized.</typeparam>
        /// <param name="json">The serialization string.</param>
        /// <returns>Returns the object deserialized from the JSON string.</returns>
        public static T FromJSON<T>(string json) where T : class
        {
            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
    }
}
