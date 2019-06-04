using Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer.Result
{
   public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location)
            :base (HttpResponseStatusCode.SeeOther)
        {
            this.Headers.AddHeader(new HttpHeader("Location", location));
        }
    }
}
