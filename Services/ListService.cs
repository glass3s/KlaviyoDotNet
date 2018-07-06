using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlaviyoDotNet.Util;
using KlaviyoDotNet.Components;
using KlaviyoDotNet.Exceptions;
using KlaviyoDotNet.Services;
using System.Web;

namespace KlaviyoDotNet.Services
{
    public class ListService : BaseService, IListService
    {
        public ListService(IUserServiceContext userServiceContext)
            : base(userServiceContext) { }

        public Dictionary<string, object> CheckList(string email)
        {
            throw new NotImplementedException();
        }

        public Lists GetList(string listId = null)
        {
            if (listId == null)
                throw new IllegalArgumentException(Resources.Errors.GeneralId);

            string url = string.Concat(Settings.Endpoints.Default.BaseUrl, string.Format(Settings.Endpoints.Default.Lists, listId));
            RawApiResponse response = RestClient.Get(url, UserServiceContext.ApiKey);
            try
            {
                Lists lists = response.Get<Lists>();
                return lists;
            }
            catch (Exception ex)
            {
                throw new KlaviyoException(ex.ToString());
            }
        }

        public List<Lists> GetList(ListGetType listGetType)
        {
            List<Lists> klaviyoList = new List<Lists>();
            RawApiResponse response;
            int start = 0, end = 0, page = 0, total = 2;
            try
            {
                while (end < total - 1)
                {
                    string url = string.Concat(Settings.Endpoints.Default.BaseUrl, Settings.Endpoints.Default.Lists, $"?page={page}");
                    if (listGetType != ListGetType.all)
                        url += $"&type={listGetType}";

                    response = RestClient.Get(url, UserServiceContext.ApiKey);
                    ResultSet<Lists> listsResponse = response.Get<ResultSet<Lists>>();
                    klaviyoList.AddRange(listsResponse.Results);
                    start = listsResponse.start;
                    end = listsResponse.end;
                    page = listsResponse.page;
                    total = listsResponse.total;
                }
                return klaviyoList;
            }
            catch (Exception ex)
            {
                throw new KlaviyoException(ex.ToString());
            }
        }

        public enum ListGetType
        {
            list, segment, all
        }

        public Lists CreateList(Lists lists)
        {
            if (lists == null)
                throw new IllegalArgumentException(Resources.Errors.GeneralId);

            string url = String.Concat(Settings.Endpoints.Default.BaseUrl, Settings.Endpoints.Default.Lists);
            RawApiResponse response = RestClient.Post(url, UserServiceContext.ApiKey, lists.ToJSON());

            try
            {
                Lists list = response.Get<Lists>();
                return list;
            }
            catch (Exception ex)
            {
                throw new KlaviyoException(ex.ToString());
            }
        }

        public Lists DeleteList(string id)
        {
            throw new NotImplementedException();
        }

        public ExcludeUnsubscribeResponse ExcludeOrUnscribe(string email, string listId = null)
        {
            if(string.IsNullOrEmpty(email))
                throw new IllegalArgumentException(Resources.Errors.GeneralId);

            string url = string.Empty;

            if(listId == null)
                url = String.Concat(Settings.Endpoints.Default.BaseUrl, Settings.Endpoints.Default.ListsExclusions);
            else
                url = String.Concat(Settings.Endpoints.Default.BaseUrl, string.Format(Settings.Endpoints.Default.ListExclusions, listId));

            RawApiResponse response = RestClient.PostXwwwFormUrlEncoded(url, UserServiceContext.ApiKey, HttpUtility.UrlEncode("email" + "=" + email));

            try
            {
                ResultSet<ExcludeUnsubscribeResponse> excludeUnsubscribeResponse = response.Get<ResultSet<ExcludeUnsubscribeResponse>>();
                return excludeUnsubscribeResponse.Results.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new KlaviyoException(ex.ToString());
            }
        }

        public bool ExcludeOrUnscribe(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new IllegalArgumentException(Resources.Errors.GeneralId);

            string url = string.Concat(Settings.Endpoints.Default.BaseUrl, Settings.Endpoints.Default.ListsExclusions);
            RawApiResponse response = RestClient.PostXwwwFormUrlEncoded(url, UserServiceContext.ApiKey, HttpUtility.UrlEncode("email" + "=" + email));

            try
            {
                var excludeUnsubscribeResponse = response.Get<Dictionary<string, bool>>();
                return true;
            }
            catch (Exception ex)
            {
                throw new KlaviyoException(ex.ToString());
            }
        }

        public Lists UpdateList(KeyValuePair<string, string> listInfo)
        {
            if(listInfo.Equals(new KeyValuePair<string, string>()))
                throw new IllegalArgumentException(Resources.Errors.GeneralId);

            string url = String.Concat(Settings.Endpoints.Default.BaseUrl, Settings.Endpoints.Default.List);
            RawApiResponse response = RestClient.PostXwwwFormUrlEncoded(url, UserServiceContext.ApiKey, listInfo.Key + "=" + listInfo.Value);

            try
            {
                Lists list = response.Get<Lists>();
                return list;
            }
            catch (Exception ex)
            {
                throw new KlaviyoException(ex.ToString());
            }
        }

        public Dictionary<string, object> AddPersonToList(string listId, KeyValuePair<string, string> personEmail)
        {
            if (personEmail.Key != "email")
                throw new IllegalArgumentException(Resources.Errors.GeneralId);

            string url = String.Concat(Settings.Endpoints.Default.BaseUrl, string.Format(Settings.Endpoints.Default.ListMembers, listId));
            RawApiResponse response = RestClient.PostXwwwFormUrlEncoded(url, UserServiceContext.ApiKey, personEmail.Key + "=" + personEmail.Value);

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
    }
}
