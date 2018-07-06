using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlaviyoDotNet.Components;
using KlaviyoDotNet.Exceptions;
using KlaviyoDotNet.Util;

namespace KlaviyoDotNet.Services
{
    public class TrackAndIdentifyService : BaseService, ITrackAndIdentifyService
    {
        public TrackAndIdentifyService(IUserServiceContext userServiceContext) 
            : base(userServiceContext)
        {
        }

        public short Identify(IdentifyRequest identifyRequest)
        {
            if (identifyRequest == null)
                throw new IllegalArgumentException(Resources.Errors.GeneralId);

            // Base64 encode the request so that we may send it. 
            byte[] propertyBytes = Encoding.ASCII.GetBytes(identifyRequest.ToJSON());
            string base64String = Convert.ToBase64String(propertyBytes);

            string url = String.Concat(Settings.Endpoints.Default.ServerSideApiUrl, string.Format(Settings.Endpoints.Default.Identify, base64String));
            RawApiResponse response = RestClient.Get(url, UserServiceContext.ApiKey);
            try
            {
                short result = Convert.ToInt16(response.Body);
                return result;
            }
            catch (Exception ex)
            {
                throw new KlaviyoException(ex.ToString());
            }
        }

        public short Track(TrackRequest trackRequest)
        {
            if(trackRequest == null)
                throw new IllegalArgumentException(Resources.Errors.GeneralId);

            // Base64 encode the request so that we may send it. 
            byte[] propertyBytes = Encoding.ASCII.GetBytes(trackRequest.ToJSON());
            string base64String = Convert.ToBase64String(propertyBytes);

            string url = String.Concat(Settings.Endpoints.Default.ServerSideApiUrl, string.Format(Settings.Endpoints.Default.Track, base64String));
            RawApiResponse response = RestClient.Get(url, UserServiceContext.ApiKey);
            try
            {
                short result = Convert.ToInt16(response.Body);
                return result;
            }
            catch (Exception ex)
            {
                throw new KlaviyoException(ex.ToString());
            }
        }
    }
}
