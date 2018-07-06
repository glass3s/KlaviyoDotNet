using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlaviyoDotNet.Util;
using KlaviyoDotNet.Components;
using KlaviyoDotNet.Exceptions;
using Newtonsoft.Json;
using System.IO;

namespace KlaviyoDotNet.Services
{
    public class ProfileService : BaseService, IProfileService
    {
        public ProfileService(IUserServiceContext userServiceContext)
            : base(userServiceContext) { }

        public Dictionary<string, object> GetPerson(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new IllegalArgumentException(Resources.Errors.GeneralId);
            }

            string url = String.Concat(Settings.Endpoints.Default.BaseUrl, string.Format(Settings.Endpoints.Default.Person, id));
            RawApiResponse response = RestClient.Get(url, UserServiceContext.ApiKey);

            try
            {
                Dictionary<string, object> person = response.Get<Dictionary<string, object>>();
                return person;
            }
            catch (Exception ex)
            {
                throw new KlaviyoException(ex.ToString());
            }
        }

        public Dictionary<string, object> AddPerson(Dictionary<string, object> person)
        {
            if (person == null)
                throw new IllegalArgumentException(Resources.Errors.GeneralId);

            string url = String.Concat(Settings.Endpoints.Default.BaseUrl, string.Format(Settings.Endpoints.Default.Person, person.Where(x => x.Key == "id")));
            RawApiResponse response = RestClient.Put(url, UserServiceContext.ApiKey, JsonConvert.SerializeObject(person));
            try
            {
                Dictionary<string, object> newPerson = response.Get<Dictionary<string, object>>();
                return person;
            }
            catch (Exception ex)
            {
                throw new KlaviyoException(ex.ToString());
            }
        }
    }
}
