using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DokoMobile.WebUI.Startup))]
namespace DokoMobile.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
