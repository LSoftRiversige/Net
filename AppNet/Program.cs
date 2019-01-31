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
            DivLevelCalculator.Run();

            MyWebServer.ListenAsync("http://localhost:51111/MyApp/");

            //ClientRequest();

            Console.WriteLine("Press any key");
            Console.ReadKey();

            //RunWebServerFromLecture();

        }

        private static void RunWebServerFromLecture()
        {
            WebServer server = new WebServer("http://localhost:51111/MyApp/", @"E:\IT\Net\");
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

        private static void ClientRequest()
        {
            WebClient wc = new WebClient();
            wc.DownloadString("http://localhost:51111/MyApp/MyQuery/");
        }
    }
}