using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;

namespace SIS.WebServer.Routing
{
    public class ServerRoutingTable : IServerRoutingTable
    {
        private readonly Dictionary<HttpRequestMethod , 
            Dictionary<string, Func<IHttpRequest, IHttpResponse>>> routingTable;

        public ServerRoutingTable()
        {
            this.routingTable = new Dictionary<HttpRequestMethod, Dictionary<string, Func<IHttpRequest, IHttpResponse>>>
            {
                [HttpRequestMethod.Get] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Post] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Put] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>(),
                [HttpRequestMethod.Delete] = new Dictionary<string, Func<IHttpRequest, IHttpResponse>>()
            };
        }

        public void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpResponse> func)
        {
            CoreValidator.ThrowIfNull(method, nameof(method));
            CoreValidator.ThrowIfNullOrEmpty(path, nameof(path));
            CoreValidator.ThrowIfNull(func, nameof(func));

            this.routingTable[method].Add(path, func);
        }

        public bool Contains(HttpRequestMethod requestMethod, string path)
        {
            CoreValidator.ThrowIfNull(requestMethod, nameof(requestMethod));
            CoreValidator.ThrowIfNullOrEmpty(path, nameof(path));

           return this.routingTable.ContainsKey(requestMethod) && this.routingTable[requestMethod].ContainsKey(path);
        }

        // ???
        public Func<IHttpRequest, IHttpResponse> Get(HttpRequestMethod requestMethod, string path)
        {
            CoreValidator.ThrowIfNull(requestMethod, nameof(requestMethod));
            CoreValidator.ThrowIfNullOrEmpty(path, nameof(path));

            return this.routingTable[requestMethod][path];
        }
    }
}
