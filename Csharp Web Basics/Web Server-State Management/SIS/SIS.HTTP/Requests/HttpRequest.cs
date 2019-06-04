using Common;
using Enums;
using Exceptions;
using SIS.HTTP.Cookies;
using SIS.HTTP.Headers;
using SIS.HTTP.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
            this.ParseRequest(requestString);
        }

        public string Path { get;private set; }

        public string Url { get;private set; }

        public Dictionary<string, object> FormData { get; }
        public Dictionary<string, object> QueryData { get; }
        public IHttpHeaderCollection Headers { get; }

        public IHttpCookieCollection Cookies { get; }
        public HttpRequestMethod RequestMethod { get; private set; }
        public IHttpSession Session { get ; set ; }

        private bool IsValidRequestLine(string[] requestLine)
        {
            if (requestLine.Length != 3 ||
                requestLine[2] != GlobalConstants.HttpOneProtocolFragments)
            {
                return false;
            }

            return true;
        }

        private bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            CoreValidator.ThrowIfNullOrEmpty(queryString, nameof(queryString));

            return true;
        }

        private void ParseRequestMethod(string[] requestLine)
        {
            HttpRequestMethod method;
            var parseResult = HttpRequestMethod.TryParse(requestLine[0], true, out method);

            if (!parseResult)
            {
                throw new BadRequestException
                    (string.Format(GlobalConstants.UnsupportedHttpMethodExceptionMessage, requestLine[0]));
            }

            this.RequestMethod = method;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            this.Url = requestLine[1];
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url.Split("?")[0];
        }

        private void ParseHeaders(string[] requestLine)
        {
            requestLine.Select(x => x.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(headerKVP => this.Headers.AddHeader(new HttpHeader(headerKVP[0], headerKVP[1])));
        }

        private IEnumerable<string> ParsePlainRequestHeaders(string[] requestLines)
        {
            for (int i = 1; i <= requestLines.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(requestLines[i]))
                {
                    yield return requestLines[i];
                }
            }
        }

        private void ParseCookies()
        {
            if (this.Headers.ContainsHeader(HttpHeader.Cookie))
            {
                string value = this.Headers.GetHeader(HttpHeader.Cookie).Value;

                string[] unparsedCookies = value.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var unparsedCookie in unparsedCookies)
                {
                    string[] cookieKeyValuePair = unparsedCookie.Split('=');

                    HttpCookie httpCookie = new HttpCookie(cookieKeyValuePair[0], cookieKeyValuePair[1], false);

                    this.Cookies.AddCookie(httpCookie);
                }
            }
        }
        private void ParseQueryParameters()
        {
            if (this.HasQueryString())
            {
                this.Url.Split("?")[1].Split(new char[] { '?', '#' })[1]
               .Split("&")
               .Select(queryParameter => queryParameter.Split("="))
               .ToList()
               .ForEach(queryParameterKVP => this.QueryData.Add(queryParameterKVP[0], queryParameterKVP[1]));
            }
        }

        private bool HasQueryString()
        {
            return this.Url.Split("?").Length > 1;
        }

        private void ParseFormDataParameters(string formData)
        {
            if (!string.IsNullOrEmpty(formData))
            {
                // To Do: Parse Multiple Parameters by Name 
                formData
                    .Split("&")
                    .Select(queryParameter => queryParameter.Split("="))
                    .ToList()
                    .ForEach(queryParameterKVP => this.FormData.Add(queryParameterKVP[0], queryParameterKVP[1]));

                // Тук може да има бъг за изпита !!!
            }
        }

        private void ParseRequestParameters(string formData)
        {
            this.ParseQueryParameters();
            this.ParseFormDataParameters(formData);
        }

        private void ParseRequest(string requestString)
        {
            var splitRequestContent = requestString
                .Split(new[] { GlobalConstants.HttpNewLine }, StringSplitOptions.None);

            var requestLine = splitRequestContent[0]
                .Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();

            this.ParseHeaders(this.ParsePlainRequestHeaders(splitRequestContent).ToArray());
            this.ParseCookies();

            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1]);
        }
    }
}
