﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using KlaviyoDotNet.Util;

namespace KlaviyoDotNet.Services
{
    public class BaseService : IBaseService
    {
        /// <summary>
        /// User service context
        /// </summary>
        public IUserServiceContext UserServiceContext { get; private set; }

        /// <summary>
        /// Get the rest client being used by the service.
        /// </summary>
        public virtual IRestClient RestClient { get; set; }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="userServiceContext"></param>
        public BaseService(IUserServiceContext userServiceContext)
        {
            this.UserServiceContext = userServiceContext;
            this.RestClient = new RestClient();
        }

        /// <summary>
        /// Constructor with the option to to supply an alternative rest client to be used.
        /// </summary>
        /// <param name="restClient">RestClientInterface implementation to be used in the service.</param>
        /// <param name="userServiceContext">User service context.</param>
        public BaseService(IRestClient restClient, IUserServiceContext userServiceContext)
        {
            this.RestClient = restClient;
            this.UserServiceContext = userServiceContext;
        }       /// <summary>
                /// Constructs the query with specified parameters.
                /// </summary>
                /// <param name="prms">An array of parameter name and value combinations.</param>
                /// <returns>Returns the query part of the URL.</returns>
        public static string GetQueryParameters(params object[] prms)
        {
            string query = null;
            if (prms != null)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < prms.Length; i += 2)
                {
                    if (prms[i + 1] == null)
                        continue;

                    if (sb.Length == 0)
                    {
                        sb.Append("?");
                    }
                    else if (sb.Length > 0)
                    {
                        sb.Append("&");
                    }
                    sb.AppendFormat("{0}={1}", HttpUtility.UrlEncode(prms[i].ToString()), HttpUtility.UrlEncode(prms[i + 1].ToString()));
                }
                query = sb.ToString();
            }

            return query;
        }

        /// <summary>
        /// Creates the URL for API access.
        /// </summary>
        /// <param name="urlPart">URL part.</param>
        /// <param name="prms">Additional parameters for URL formatting.</param>
        /// <param name="queryList">Query parameters to add to the URL.</param>
        /// <returns>Returns the URL with all specified query parameters.</returns>
        public static string ConstructUrl(string urlPart, object[] prms, object[] queryList)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Settings.Endpoints.Default.BaseUrl);
            if (prms == null)
            {
                sb.Append(urlPart);
            }
            else
            {
                sb.AppendFormat(urlPart, prms);
            }
            if (queryList != null)
            {
                sb.Append(BaseService.GetQueryParameters(queryList));
            }

            return sb.ToString();
        }

    }

    /// <summary>
    /// User service context class
    /// </summary>
    public class UserServiceContext : IUserServiceContext
    {

        /// <summary>
        /// Application api key
        /// </summary>
        public string ApiKey { get; protected set; }

        /// <summary>
        /// Account service constructor
        /// </summary
        /// <param name="apiKey">The API key for the application</param>
        public UserServiceContext(string apiKey)
        {
            ApiKey = apiKey;
        }
    }

    /// <summary>
    /// User service context interface
    /// </summary>
    public interface IUserServiceContext
    {
        /// <summary>
        /// Application api key
        /// </summary>
        string ApiKey { get; }
    }
}
