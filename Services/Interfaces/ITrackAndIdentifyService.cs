using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlaviyoDotNet.Components;

namespace KlaviyoDotNet.Services
{
    public interface ITrackAndIdentifyService : IBaseService
    {
        /// <summary>
        /// Used to track properties about an individual without tracking an associated event
        /// Quick way to add customer information. 
        /// </summary>
        /// <param name="identifyRequest">Match the exact email address.</param>
        /// <returns>Returns either 1, for success, or 0, for failure.</returns>
        short Identify(IdentifyRequest identifyRequest);

        short Track(TrackRequest trackRequest);
    }
}
