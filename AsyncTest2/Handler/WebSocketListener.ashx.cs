using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Web.WebSockets;

namespace AsyncTest2.Handler
{
    /// <summary>
    /// Summary description for Handler2
    /// </summary>
    public class WebSocketListener : WebSocketHandler
    {
        public override void OnMessage(string message)
        {
            Send(message);
        }
    }
}