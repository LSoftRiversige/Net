using System.Net;

namespace AppNet
{
    public interface IResponceController
    {
        string GetResponceText(HttpListenerContext context);
    }
}