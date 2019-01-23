using System;
using System.Net;
using System.Net.Http;

namespace AppNet
{
    class Program
    {
        static void Main(string[] args)
        {
            DivLevelCalculator.Run();

            MyWebServer.ListenAsync("http://localhost:51111/MyApp/");

            WebClient wc = new WebClient();
            wc.DownloadString("http://localhost:51111/MyApp/MyQuery/");

            Console.WriteLine("Press any key");
            Console.ReadKey();

            //WebServer server = new WebServer("http://localhost:51111/MyApp/", @"E:\IT\Net\");
            //try
            //{
            //    server.Start();
            //    Console.ReadKey();
            //}
            //finally
            //{
            //    server.Stop();
            //}


        }
    }
}
