using Enums;
using SIS.HTTP.Cookies;
using SIS.HTTP.Headers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Responses
{
   public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }
        
        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        void AddCookie(HttpCookie cookie);

        byte[] GetBytes();
    }
}
