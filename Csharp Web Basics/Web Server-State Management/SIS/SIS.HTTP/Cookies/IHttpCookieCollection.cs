using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Cookies
{
   public interface IHttpCookieCollection
    {
        void AddCookie(HttpCookie cookie);

        bool ContainsCookie(string key);

        HttpCookie GetCookie(string key);

        bool HasCookies();
    }
}
