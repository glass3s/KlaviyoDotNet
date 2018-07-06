using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlaviyoDotNet.Util;

namespace KlaviyoDotNet.Services
{
    public interface IBaseService
    {
        /// <summary>
        /// User service context
        /// </summary>
        IUserServiceContext UserServiceContext { get; }

        /// <summary>
        /// Returns the REST client object.
        /// </summary>
        IRestClient RestClient { get; }
    }
}
