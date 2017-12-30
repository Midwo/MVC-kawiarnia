using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_kawiarnia.Startup))]
namespace MVC_kawiarnia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
