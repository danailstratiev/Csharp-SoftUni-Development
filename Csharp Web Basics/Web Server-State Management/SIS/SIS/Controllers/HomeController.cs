using Enums;
using SIS.Demo.Controllers;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS
{
   public class HomeController : BaseController
    {
        public IHttpResponse Home (IHttpRequest request)
        {
            this.HttpRequest = request;

            return this.View();
        }

        public IHttpResponse Login (IHttpRequest request)
        {
            request.Session.ClearParameters();

            return this.Redirect("/");
        }

        
    }
}
