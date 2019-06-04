using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Common;
using System.Collections;

namespace SIS.HTTP.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection, IEnumerable
    {
        private readonly Dictionary<string, HttpCookie> httpCookies;

        public HttpCookieCollection()
        {
            this.httpCookies = new Dictionary<string, HttpCookie>();
        }

        public void AddCookie(HttpCookie cookie)
        {
            CoreValidator.ThrowIfNull(cookie, nameof(cookie));

            this.httpCookies[cookie.Key] = cookie;
        }

        public bool ContainsCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.httpCookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            
            return this.httpCookies[key];
        }

        public IEnumerator GetEnumerator()
        {
            return this.httpCookies.Values.GetEnumerator();
        }

        public bool HasCookies()
        {
            return this.httpCookies.Count != 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var cookie in this.httpCookies.Values)
            {
                sb.Append($"Set-Cookie: {cookie}").Append(GlobalConstants.HttpNewLine);    
            }

            return sb.ToString();
        }
    }
}
