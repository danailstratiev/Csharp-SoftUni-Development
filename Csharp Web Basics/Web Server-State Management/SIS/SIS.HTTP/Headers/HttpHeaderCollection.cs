using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void AddHeader(HttpHeader header)
        {
            this.headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            var foundHeader = this.headers.FirstOrDefault(x => x.Key == key).Value;

            return foundHeader;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var header in this.headers)
            {
                sb.AppendLine(header.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
