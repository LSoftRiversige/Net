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

            

            string msg = GetRequestText(context);
            context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(msg);
            context.Response.StatusCode = (int)HttpStatusCode.OK;

            using (Stream s = context.Response.OutputStream)
            using (StreamWriter writer = new StreamWriter(s))
            {
                await writer.WriteAsync(msg);
            }
            listener.Stop();
        }

        private static string GetRequestText(HttpListenerContext context)
        {
            var s = new StringBuilder();
            s.Append("<html lang=\"ru\">");
            s.Append("<body><meta charset=\"utf-8\">");
            s.Append("<head>");
            s.Append("<title> Отображение заголовка HTTP запроса</title>");
            s.Append("</head>");
            s.Append("<h1> Отображение заголовка HTTP запроса</h1>");
            s.Append("<div>");

            s.Append($"<p style=\"color: red;\"><b>GET {context.Request.RawUrl}  HTTP/{context.Request.ProtocolVersion}</b></p>");
            NameValueCollection headers = context.Request.Headers;
            for (int i = 0; i < headers.Count; i++)
            {
                s.Append($"<p><b>{headers.GetKey(i)}</b>: {headers[i]}</p>");
            }
            s.Append("</div>");
            s.Append("</body>");
            s.Append("</html>");
            return s.ToString();
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
