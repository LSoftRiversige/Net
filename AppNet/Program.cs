using System;
using System.Net;
using System.Net.Http;

//https://github.com/LSoftRiversige/Net.git

namespace AppNet
{
    class Program
    {
        static void Main(string[] args)
        {
            RunWebServer();
        }

        private static void RunWebServer()
        {
            WebServer server = new WebServer("http://localhost:51111/MyApp/", "/MyApp/", @"C:\Dev\C#\Net", @"C:\Dev\C#\Net\ResponceControllers\bin\Debug\netcoreapp2.1\ResponceControllers.dll");
            try
            {
                server.Start();
                Console.ReadKey();
            }
            finally
            {
                server.Stop();
            }
        }

        //private static void ClientRequest()
        //{
        //    WebClient wc = new WebClient();
        //    wc.DownloadString("http://localhost:51111/MyApp/MyQuery/");
        //}

        //private static void OldCode()
        //{
        //    //DivLevelCalculator.Run();

        //    //MyWebServer.ListenAsync("http://localhost:51111/MyApp/");"", 

        //    //ClientRequest();
        //}
    }
}