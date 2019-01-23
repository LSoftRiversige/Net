using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace AppNet
{
    public class MyWebServer
    {
        public async static void ListenAsync(string address)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(address);
            listener.Start();

            HttpListenerContext context = await listener.GetContextAsync();

            PrintRequestHeaders(context);

            string msg = "You asked for " + context.Request.RawUrl;
            context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(msg);
            context.Response.StatusCode = (int)HttpStatusCode.OK;

            using (Stream s = context.Response.OutputStream)
            using (StreamWriter writer = new StreamWriter(s))
            {
                await writer.WriteAsync(msg);
            }
            listener.Stop();
        }

        public static void PrintRequestHeaders(HttpListenerContext context)
        {
            Console.WriteLine($"GET {context.Request.RawUrl}  HTTP/{context.Request.ProtocolVersion}");
            NameValueCollection headers = context.Request.Headers;
            for (int i = 0; i < headers.Count; i++)
            {
                Console.WriteLine("{0}: {1}", headers.GetKey(i), headers[i]);
            }
        }
    }
}
