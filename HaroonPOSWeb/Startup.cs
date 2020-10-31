using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HaroonPOSWeb.Startup))]
namespace HaroonPOSWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
