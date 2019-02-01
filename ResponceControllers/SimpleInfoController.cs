using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ResponceControllers
{
    public class SimpleInfoController: AppNet.IResponceController
    {
        public string GetResponceText(HttpListenerContext context)
        {
            var s = new StringBuilder();
            s.Append("<!DOCTYPE html>");
            s.Append("<html>");
            s.Append("  <head>");
            s.Append("      <title>Lorem ipsum</title>");
            s.Append("  </head>");
            s.Append("  <body>");
            s.Append("      <div>");
            s.Append("          <p>");
            s.Append("              Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            s.Append("          </p>");
            s.Append("      </div>");
            s.Append("  </body>");
            s.Append("</html>");
            return s.ToString();
        }
    }
}
