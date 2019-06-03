using Enums;
using SIS.HTTP.Cookies;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Result;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace SIS.Demo.Controllers
{
   public abstract class BaseController
    {
        public IHttpRequest HttpRequest { get; set; }
        private bool IsLoggedIn()
        {
            return this.HttpRequest.Session.ContainsParameter("username");
        }

        public IHttpResponse View([CallerMemberName] string view = null)
        {
            var controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            var viewName = view;

            var viewContent = File.ReadAllText("Views/" + controllerName + "/" + viewName +  ".html");

            viewContent = this.ParseTemplate(viewContent);

            var htmlResult = new HtmlResult(viewContent, HttpResponseStatusCode.Ok);

            htmlResult.Cookies.AddCookie(new HttpCookie("lang", "en"));

            return htmlResult;
        }

        private string ParseTemplate(string viewContent)
        {
            if (this.IsLoggedIn())
            {
                return viewContent.Replace("@Model.HelloMessage", $"Hello, {this.HttpRequest.Session.GetParameter("username")}");
            }
            else
            {
                return viewContent.Replace("@Model.HelloMessage", "Hello World From the SIS.Server!");
            }
        }

        public IHttpResponse Redirect(string url)
        {
            return new RedirectResult(url);
        }
    }
}
