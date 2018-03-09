using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StarterWeb.Startup))]
namespace StarterWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
