using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;

namespace AsyncTest2.Handler
{
    /// <summary>
    /// Summary description for WebSocketRequester
    /// </summary>
    public class WebSocketRequester : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.AcceptWebSocketRequest(new WebSocketListener());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}