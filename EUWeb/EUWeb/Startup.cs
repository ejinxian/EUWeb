using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EUWeb.Startup))]
namespace EUWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
