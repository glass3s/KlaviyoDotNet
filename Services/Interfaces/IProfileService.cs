using System;
using System.Collections.Generic;
using KlaviyoDotNet.Components;

namespace KlaviyoDotNet.Services
{
    public interface IProfileService : IBaseService
    {
        Dictionary<string, object> GetPerson(string id);

        Dictionary<string, object> AddPerson(Dictionary<string, object> person);
    }
}
