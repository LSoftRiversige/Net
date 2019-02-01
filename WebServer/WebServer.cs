using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppNet
{
    public class WebServer
    {
        HttpListener _listener;
        string _baseFolder;
        string _baseAddress;
        string _dllControllersName;

        public WebServer(string prefixUrl, string baseAddress, string baseFolder, string dllControllersName)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(prefixUrl);
            _baseFolder = baseFolder;
            _baseAddress = baseAddress;
            _dllControllersName = dllControllersName;
        }

        public async void Start()
        {
            _listener.Start();

            while (true)
            {
                HttpListenerContext context = await _listener.GetContextAsync();
                Task.Run(() => ProcessRequestAsync(context));
            }
        }

        public void Stop()
        {
            _listener.Stop();
        }

        private async void ProcessRequestAsync(HttpListenerContext context)
        {
            string command = context.Request.RawUrl;
            string controllerName = command.Replace(_baseAddress, "") + "Controller";

            byte[] msg;

            IResponceController controller = ControllerResolver.FindByName(_dllControllersName, controllerName);
            if (controller != null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                msg = Encoding.UTF8.GetBytes(controller.GetResponceText(context));
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                msg = Encoding.UTF8.GetBytes(string.Format("Controller {0} not found", controllerName));
            }

            await SendResponce(context, msg);
        }

        private static async Task SendResponce(HttpListenerContext context, byte[] msg)
        {
            context.Response.ContentLength64 = msg.Length;
            using (Stream s = context.Response.OutputStream)
            {
                await s.WriteAsync(msg, 0, msg.Length);
            }
        }
    }
}
