using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SoftUniHttpServer
{
    class Program
    {
        const string NewLine = "\r\n";
        static void Main(string[] args)
        {
            var tcpListener = new TcpListener(IPAddress.Loopback, 12345);

            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                // WebUtility.Decode
                Task.Run(() => ProcessClient(client));
            }
        }

        public static async Task ProcessClient(TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                var requestBytes = new byte[100000];
                var readBytes = await stream.ReadAsync(requestBytes, 0, requestBytes.Length);
                var stringRequest = Encoding.UTF8.GetString(requestBytes, 0, readBytes);
                Console.WriteLine(new string('=', 70));
                Console.WriteLine(stringRequest);

                var responseBody = DateTime.Now.ToString();
                var response = "HTTP/1.0 200 OK" + NewLine + 
                    "Content type: text/html" + NewLine +
                    "Set-Cookie: cookie1=test; Domain=.localhost" + NewLine +
                    "Server: MyCustomServer 1.0" + NewLine +
                    $"Content-Length {responseBody}";
                var responceBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responceBytes, 0, responceBytes.Length);
            }
        }
    }
}
