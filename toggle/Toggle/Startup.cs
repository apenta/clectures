using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Toggle.Startup))]

namespace Toggle
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.MapSignalR<ToggleConnection>("/togglesocket");
            app.MapSignalR();
        }
    }
}
