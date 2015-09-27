using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhoenixBootstrap.Startup))]
namespace PhoenixBootstrap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
