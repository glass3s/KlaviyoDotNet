using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlaviyoDotNet.Util
{
    public interface IRestClient
    {
        RawApiResponse Get(string url, string apiKey);
        RawApiResponse Put(string url, string apiKey, string data);
        RawApiResponse Post(string url, string apiKey, string data);
        RawApiResponse Patch(string url, string apiKey, string data);
        RawApiResponse Delete(string url, string apiKey);
        RawApiResponse PostXwwwFormUrlEncoded(string url, string apiKey, string data);
    }
}
