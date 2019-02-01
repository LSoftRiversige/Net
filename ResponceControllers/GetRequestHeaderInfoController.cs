using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using AppNet;

namespace ResponceControllers
{
    public class GetRequestHeaderInfoController: IResponceController
    {
        public string GetResponceText(HttpListenerContext context)
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
    }
}
