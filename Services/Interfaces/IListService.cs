using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlaviyoDotNet.Components;

namespace KlaviyoDotNet.Services
{
    public interface IListService : IBaseService
    {
        Lists GetList(string id = null);

        Lists UpdateList(KeyValuePair<string, string> listInfo);

        Lists CreateList(Lists lists);

        Lists DeleteList(string id);

        Dictionary<string, object> AddPersonToList(string listId, KeyValuePair<string, string> personEmail);

        Dictionary<string, object> CheckList(string email);

        ExcludeUnsubscribeResponse ExcludeOrUnscribe(string email, string listId);

        bool ExcludeOrUnscribe(string email);
    }
}
