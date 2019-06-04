using SIS.HTTP.Sessions;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer.Sessions
{
   public class HttpSessionsStorage
    {
        public const string SessionCookieKey = "SIS_ID";

        private static readonly ConcurrentDictionary<string, IHttpSession> httpSessions =
            new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession GetSession(string id)
        {
            return httpSessions.GetOrAdd(id, _ => new HttpSession(id));

            //_ We just skip the parameter
        }
    }
}
