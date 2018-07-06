using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KlaviyoDotNet.Util
{
    public class RestClient : IRestClient
    {
        /// <summary>
        /// Http processor
        /// </summary>
        protected HttpProcessor httpProcessor = new HttpProcessor();

        public RawApiResponse Delete(string url, string apiKey)
        {
            throw new NotImplementedException();
        }

        public RawApiResponse Get(string url, string apiKey)
        {
            return HttpRequest(url, HttpMethod.GET, apiKey, null);
        }

        public RawApiResponse Patch(string url, string apiKey, string data)
        {
            return HttpRequest(url, HttpMethod.PATCH, apiKey, data);
        }

        public RawApiResponse Post(string url, string apiKey, string data)
        {
            return HttpRequest(url, HttpMethod.POST, apiKey, data);
        }

        public RawApiResponse Put(string url, string apiKey, string data)
        {
            return HttpRequest(url, HttpMethod.PUT, apiKey, data);
        }

        private RawApiResponse HttpRequest(string url, HttpMethod httpMethod, string apiKey, string data)
        {
            return httpProcessor.HttpRequest(url, httpMethod, new JsonContentType(), apiKey, data);
        }

        public RawApiResponse PostXwwwFormUrlEncoded(string url, string apiKey, string data)
        {
            return httpProcessor.HttpRequest(url, HttpMethod.POST, new FormDataContentType(), apiKey, data);
        }
    }
}
