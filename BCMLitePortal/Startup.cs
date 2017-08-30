using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BCMLitePortal.Startup))]
namespace BCMLitePortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
