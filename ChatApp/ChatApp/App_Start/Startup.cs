using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using ChatApp.PConn;

[assembly: OwinStartup(typeof(ChatApp.App_Start.Startup))]

namespace ChatApp.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<ChatConnection>("/chat");
        }
    }
}
