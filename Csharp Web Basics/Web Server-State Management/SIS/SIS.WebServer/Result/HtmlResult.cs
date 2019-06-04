using Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer.Result
{
   public class HtmlResult : HttpResponse
    {
        public HtmlResult(string content, HttpResponseStatusCode responseStatusCode)
           : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader("Content-Type", "text/html; charset = utf-8"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
