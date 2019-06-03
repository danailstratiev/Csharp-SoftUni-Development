using Enums;
using SIS.WebServer;
using SIS.WebServer.Routing;
using System;

namespace SIS
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(HttpRequestMethod.Get, "/", request => new HomeController().Home(request));

            serverRoutingTable.Add(HttpRequestMethod.Get, "/login", request => new HomeController().Login(request));

            Server server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}
